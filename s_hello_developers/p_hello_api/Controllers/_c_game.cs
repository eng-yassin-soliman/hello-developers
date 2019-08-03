using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;
using Newtonsoft.Json;

namespace p_hello_api.Controllers
{
    public class _c_player
    {
        public string s_nam_ { get; set; }  // Name
        public string s_pas_ { get; set; }  // Password
        public string s_ssn_ { get; set; }  // Session id

        public string s_sgn_ { get; set; }  // Symbol
        public string s_clr_ { get; set; }  // Color

        public int s_win_ { get; set; }     // Score
        public int s_los_ { get; set; }     // How many loses

        public byte s_clk_ { get; set; }    // Cell clicked
        public int[] s_brd_ { get; set; }  // Board configuration e.x: { 0, x, o, 0, x, o, 0, x, x }

        public _c_player(string p_nam_, string p_sgn_, string p_pas_)
        {
            s_nam_ = p_nam_;
            s_pas_ = p_pas_;
            s_sgn_ = p_sgn_;
            s_brd_ = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        // يحسب ترتيب الخلية من إحداثياتها
        public static byte f_tondx_(byte[] p_crd_)
        {
            return (byte)((p_crd_[0] * 3) + p_crd_[1]);
        }

        // يحسب احداثيات الخلية من ترتيبها
        public static byte[] f_tocrd_(byte p_ndx_)
        {
            byte l_row_ = (byte)Math.Floor((double)(p_ndx_ / 3));
            byte l_col_ = (byte)(p_ndx_ - (3 * l_row_));
            return new byte[] { l_col_, l_row_ };
        }

        /// <summary>
        /// هل الخلية ليها 2 جيران من نوع محدد
        /// </summary>
        public static Boolean f_neighbour_(byte p_cel_, byte[] p_lst_)
        {
            byte[] l_crd_ = _c_player.f_tocrd_(p_cel_);

            // كام خلية في نفس الصف
            int q_col_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_cel_ &&
                          _c_player.f_tocrd_(i_byt_)[0] == l_crd_[0]
                          select i_byt_).Count();

            if (q_col_ == 2) { return true; }

            // كام خلية في نفس العمود
            int q_row_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_cel_ &&
                          _c_player.f_tocrd_(i_byt_)[1] == l_crd_[1]
                          select i_byt_).Count();

            if (q_row_ == 2) { return true; }

            // لو الخلية الفاضية في أحد الأركان
            byte[] l_crn_ = { 0, 2, 6, 8 }; // الأركان
            byte[] l_inv_ = { 8, 6, 2, 0 }; // الركن المقابل
            if (l_crn_.Contains(p_cel_))
            {
                byte l_ops_ = l_inv_[Array.IndexOf(l_crn_ , p_cel_)];

                if (p_lst_.Contains((byte)4) &&
                    p_lst_.Contains(l_ops_))
                { return true; } // لو في خلية في الركن المقابل وخلية في الوسط
            }

            // الاحتمال الاخير انها تبقى الخلية اللي في الوسط
            if (p_cel_ != 4)
            { return false; }

            return (
                (p_lst_.Contains((byte)0) && p_lst_.Contains((byte)8)) ||
                (p_lst_.Contains((byte)2) && p_lst_.Contains((byte)6)));
        }

        /// <summary>
        /// تجرب الدالة اللي فاتت على كل الخلايا من نوع معين
        /// </summary>
        /// <param name="p_tp1_">
        /// نوع الخلايا اللي بابحث عن جيران لها
        /// </param>
        /// <param name="p_tp2_">
        /// نوع الخلايا الجارة اللي بابحث عنها
        /// </param>
        /// <param name="p_brd_">
        /// المصفوفة اللي فيها كل الخلايا
        /// </param>
        /// <returns>
        /// بيرجع أول خليه ليها 2 جيران من النوع المحدد
        /// لو ملقاش بيرجع 9
        /// </returns>
        public static byte f_status_(byte p_tp1_, byte p_tp2_, int[] p_brd_)
        {
            List<byte> l_tp1_ = new List<byte>();
            List<byte> l_tp2_ = new List<byte>();

            for (byte i_ndx_ = 0; i_ndx_ < 9; i_ndx_ ++)
            {
                if (p_brd_[i_ndx_] == p_tp1_)
                {
                    l_tp1_.Add(i_ndx_);
                }

                if (p_brd_[i_ndx_] == p_tp2_)
                {
                    l_tp2_.Add(i_ndx_);
                }
            }

            foreach (byte i_ndx_ in l_tp1_)
            {
                if (f_neighbour_(i_ndx_, l_tp2_.ToArray())) { return i_ndx_; }
            }

            return 9;
        }
    }

    [Route("tictac")]
    [ApiController]
    public class _c_tictac : Controller
    {
        public static _c_player[] s_ply_ = {
            new _c_player("Y", "Y", "21837a6f191538b6"),    // Yassin
            new _c_player("H", "H", "88ee1becbe986b54"),    // Ahmed Hammam
            new _c_player("R", "R", "d7587a1820c44ca4"),    // Ahmed Rahim
            new _c_player("M", "M", "467ee5c36e34bbea"),    // Ahmed Magdi
            new _c_player("K", "K", "4b572e4865116c34"),    // Ahmed Khaled
            new _c_player("D", "D", "87114d4f0965fc5c"),    // Dina
            new _c_player("B", "B", "4bdb22e16a664bd2"),    // Heba
            new _c_player("T", "T", "64e7a549afc602d8")};   // Test

        [HttpPost]
        [Route("play")]
        public _c_player[] f_play_(_c_player p_ply_)
        {
            // Check incoming password not empty or null
            if (string.IsNullOrEmpty(p_ply_.s_pas_))
            { return new _c_player[] { new _c_player("كلمة المرور غير صحيحة", "", "") }; }

            // Hash incoming password
            SHA256 l_hsh_ = SHA256.Create();
            byte[] l_inp_ = Encoding.UTF8.GetBytes(p_ply_.s_pas_);
            byte[] l_out_ = l_hsh_.ComputeHash(l_inp_);
            string l_pas_ = BitConverter.ToString(l_out_).Replace("-", "").Substring(0, 16).ToLower();

            // Does password hash list contains 
            _c_player q_ply_ = (from i_ply_ in s_ply_
                                where i_ply_.s_pas_ == l_pas_
                                select i_ply_).FirstOrDefault(); // Returns new _c_player() if no match

            // Set session
            q_ply_.s_nam_ = p_ply_.s_nam_;
            q_ply_.s_ssn_ = p_ply_.s_ssn_;
            q_ply_.s_clr_ = p_ply_.s_clr_;

            if (string.IsNullOrEmpty(q_ply_.s_pas_))
            {
                q_ply_.s_nam_ = "كلمة المرور غير صحيحة";
                return new _c_player[] { q_ply_ };
            }

            // If user just wants to load data
            if (p_ply_.s_clk_ == 9)
            { return s_ply_; }

            // If game over
            if (q_ply_.s_los_ > 9)
            { return s_ply_; }

            // Check the clicked cell is not occupied
            if (q_ply_.s_brd_[p_ply_.s_clk_] != 0)
            { return s_ply_; }

            // Add the clicked cell to user's cell
            q_ply_.s_brd_[p_ply_.s_clk_] = 1;

            // Empty cells
            byte[] l_emp_ = q_ply_.s_brd_
                .Select((p_itm_, p_ndx_) => p_itm_ == 0 ? (byte)p_ndx_ : (byte)9)
                .Where(p_itm_ => p_itm_ != 9).ToArray();

            // Calculate best move
            // لو السيرفر فاضله واحدة ويقفل: قفل
            //byte l_sts_ = 0;
            //l_sts_ = _c_player.f_status_(0, 2, q_ply_.s_brd_);
            //if (l_sts_ != 9)
            //{
            //    q_ply_.s_brd_[l_sts_] = 2;
            //    goto n_final_;
            //}

            //// لو المستخدم فاضله واحدة ويقفل: امنعه
            //l_sts_ = _c_player.f_status_(0, 1, q_ply_.s_brd_);
            //if (l_sts_ != 9)
            //{
            //    q_ply_.s_brd_[l_sts_] = 2;
            //    goto n_final_;
            //}

            // Randomize server move
            //int l_nxt_ = (new Random()).Next(0, l_emp_.Length - 1);
            //q_ply_.s_brd_[l_emp_[l_nxt_]] = 2;

            q_ply_.s_brd_[l_emp_[0]] = 2;

        n_final_:
            if (!l_emp_.Any())
            {
                q_ply_.s_brd_ = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                return s_ply_;
            }

            return s_ply_;

            try
            {
                if (_c_player.f_status_(1, 1, q_ply_.s_brd_) != 9)
                { q_ply_.s_win_ += 1; } // User wins

                else if (_c_player.f_status_(2, 2, q_ply_.s_brd_) != 9)
                { q_ply_.s_los_ += 1; } // Server wins

                else if (!l_emp_.Any())
                { }                     // All cells are full

                else
                { return s_ply_; }

                q_ply_.s_brd_ = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                return s_ply_;
            }
            catch (Exception p_exp_)
            {
                return s_ply_;
            }
        }
    }
}