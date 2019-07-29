using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace p_hello_api.Controllers
{
    public class _c_player
    {
        public string s_nam_ = "";  // Name
        public string s_pas_ = "";  // Password
        public string s_ssn_ = "";  // Session id

        public string s_sgn_ = "";  // Symbol
        public string s_clr_ = "";  // Color

        public int s_win_ = 0;      // Score
        public int s_los_ = 0;      // How many loses

        public byte s_clk_ = 0;      // Cell clicked
        // Occupied cells by user
        public List<byte> s_usr_ = new List<byte>();
        // Occupied cells by server
        public List<byte> s_srv_ = new List<byte>();

        public _c_player(string p_nam_, string p_sgn_, string p_pas_)
        {
            s_nam_ = p_nam_;
            s_pas_ = p_pas_;
            s_sgn_ = p_sgn_;
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
        public static Boolean f_neighbour_(byte p_ndx_, List<byte> p_lst_)
        {
            byte[] l_crd_ = _c_player.f_tocrd_(p_ndx_);

            // كام خلية في نفس الصف
            int q_col_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_ndx_ &
                          _c_player.f_tocrd_(i_byt_)[0] == l_crd_[0]
                          select i_byt_).Count();

            if (q_col_ == 2) { return true; }

            // كام خلية في نفس العمود
            int q_row_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_ndx_ &
                          _c_player.f_tocrd_(i_byt_)[1] == l_crd_[1]
                          select i_byt_).Count();

            if (q_row_ == 2) { return true; }

            // لو الخلية الفاضية في أحد الأركان
            byte[] l_crn_ = { 0, 2, 6, 8 }; // الأركان
            byte[] l_inv_ = { 8, 6, 2, 0 }; // الركن المقابل
            if (l_crn_.Contains(p_ndx_))
            {
                byte l_ops_ = l_inv_[Array.IndexOf(l_crn_ , p_ndx_)];

                if (p_lst_.Contains(4) && p_lst_.Contains(l_ops_))
                { return true; } // لو في خلية في الركن المقابل وخلية في الوسط
            }

            // الاحتمال الاخير انها تبقى الخلية اللي في الوسط
            if (p_ndx_ != 4)
            { return false; }

            return (
                (p_lst_.Contains(0) && p_lst_.Contains(8)) ||
                (p_lst_.Contains(2) && p_lst_.Contains(6)));
        }

        /// <summary>
        /// تجرب الدالة اللي فاتت على كل الخلايا من نوع معين
        /// </summary>
        /// <param name="p_1st_">
        /// القائمة اللي عايز تجرب عليها
        /// </param>
        /// <param name="p_2nd_">
        /// القائمة اللي عايز تشوف في منها جيران لكل خلية من الخلايا اللي فاتت
        /// </param>
        /// <returns>
        /// بيرجع أول خليه ليها 2 جيران من النوع المحدد
        /// لو ملقاش بيجع 9
        /// </returns>
        public static byte f_status_(List<byte> p_1st_, List<byte> p_2nd_)
        {
            foreach (byte i_byt_ in p_1st_)
            {
                if (_c_player.f_neighbour_(i_byt_, p_2nd_))
                {
                    return i_byt_;
                }
            }

            return 9;
        }
    }

    [Route("tictac")]
    [ApiController]
    public class _c_tictac : Controller
    {
        public static _c_player[] s_ply_ = {
            new _c_player("Y", "Y", "21837a6f191538b6"),     // Yassin
            new _c_player("H", "H", "88ee1becbe986b54"),     // Ahmed Hammam
            new _c_player("R", "R", "d7587a1820c44ca4"),     // Ahmed Rahim
            new _c_player("M", "M", "467ee5c36e34bbea"),     // Ahmed Magdi
            new _c_player("K", "K", "4b572e4865116c34"),     // Ahmed Khaled
            new _c_player("D", "D", "87114d4f0965fc5c"),     // Dina
            new _c_player("B", "B", "4bdb22e16a664bd2")};    // Heba

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

            if (p_ply_.s_clk_ == 9)
            { return s_ply_; }

            if (q_ply_.s_los_ > 9)
            { return s_ply_; }

            // Empty cells
            List<byte> l_emp_ = new List<byte>();
            l_emp_.AddRange(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 });

            // Check the clicked cell is not occupied
            if (q_ply_.s_usr_.Contains(p_ply_.s_clk_) ||
                q_ply_.s_srv_.Contains(p_ply_.s_clk_))
            { goto n_final_; }

            // Add the clicked cell to user's cell
            q_ply_.s_usr_.Add(p_ply_.s_clk_);

            // Remove occupied
            l_emp_.RemoveAll(
                p_itm_ => 
                q_ply_.s_usr_.Contains(p_itm_) ||
                q_ply_.s_srv_.Contains(p_itm_));

            if (!l_emp_.Any())
            { goto n_final_; }

            byte l_sts_ = 0;

            // Calculate best move
            // لو السيرفر فاضله واحدة ويقفل: قفل
            l_sts_ = _c_player.f_status_(l_emp_, q_ply_.s_srv_);
            if (l_sts_ != 9)
            {
                q_ply_.s_srv_.Add(l_sts_);
                l_emp_.Remove(l_sts_);
                goto n_final_;
            }

            // لو المستخدم فاضله واحدة ويقفل: امنعه
            l_sts_ = _c_player.f_status_(l_emp_, q_ply_.s_usr_);
            if (l_sts_ != 9)
            {
                q_ply_.s_srv_.Add(l_sts_);
                l_emp_.Remove(l_sts_);
                goto n_final_;
            }

            // Randomize server move
            int l_nxt_ = (new Random()).Next(0, l_emp_.Count);
            q_ply_.s_srv_.Add(l_emp_[l_nxt_]);

        n_final_:
            if (_c_player.f_status_(q_ply_.s_usr_, q_ply_.s_usr_) != 9)
            { q_ply_.s_win_ += 1; } // User wins

            else if (_c_player.f_status_(q_ply_.s_srv_, q_ply_.s_srv_) != 9)
            { q_ply_.s_los_ += 1; } // Server wins

            else if (!l_emp_.Any())
            { }                     // Boxes are full

            else
            { return s_ply_; }

            q_ply_.s_usr_.Clear();
            q_ply_.s_srv_.Clear();
            return s_ply_;
        }
    }
}