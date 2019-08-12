/**
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;
using p_hello_api.DAL;

namespace p_hello_api.Controllers
{
    public class _c_state
    {
        public _c_member s_mem_;
        public _c_game s_gam_;
    }

    [ApiController]
    [Route("tictac")]
    public class _c_tictac : Controller
    {
        public _c_state[] s_ply_ = { };

        [HttpPost]
        [Route("play")]
        public _c_state[] f_play_(_c_state p_ply_)
        {
            _c_ctx l_dal_ = new _c_ctx();
            l_dal_.f_connect_();



            // Login
            if (!f_login_(p_ply_.s_mem_.s_nam_, p_ply_.s_mem_.s_pas_))
            {
                { return new _c_state[] { new _c_state() }; }
            }


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
            byte[] l_emp_;
            l_emp_ = q_ply_.s_brd_
                .Select((p_itm_, p_ndx_) => p_itm_ == 0 ? (byte)p_ndx_ : (byte)9)
                .Where(p_itm_ => p_itm_ != 9).ToArray();

            if (!l_emp_.Any()) { goto n_final_; }

            // Calculate best move
            // لو السيرفر فاضله واحدة ويقفل: قفل
            byte l_sts_ = 0;
            l_sts_ = _c_player.f_status_(0, 2, q_ply_.s_brd_);
            if (l_sts_ != 9)
            {
                q_ply_.s_brd_[l_sts_] = 2;
                goto n_final_;
            }

            // لو المستخدم فاضله واحدة ويقفل: امنعه
            l_sts_ = _c_player.f_status_(0, 1, q_ply_.s_brd_);
            if (l_sts_ != 9)
            {
                q_ply_.s_brd_[l_sts_] = 2;
                goto n_final_;
            }

            // Randomize server move
            int l_nxt_ = (new Random()).Next(0, l_emp_.Length);
            q_ply_.s_brd_[l_emp_[l_nxt_]] = 2;

        n_final_:
            if (_c_player.f_status_(1, 1, q_ply_.s_brd_) != 9)
            { q_ply_.s_win_ += 1; } // User wins

            else if (_c_player.f_status_(2, 2, q_ply_.s_brd_) != 9)
            { q_ply_.s_los_ += 1; } // Server wins

            else if (!l_emp_.Any())
            { }                     // No winner (Draw)

            else { return s_ply_; } // Game in progress

            q_ply_.s_brd_ = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            return s_ply_;
        }

        // Private methods
        /// <summary>
        /// يتحقق من اسم الدخول وكلمة المرور صحيحين
        /// </summary>
        Boolean f_login_(string p_nam_, string p_pas_)
        {
            // Hash incoming password
            SHA256 l_hsh_ = SHA256.Create();
            byte[] l_inp_ = Encoding.UTF8.GetBytes(p_pas_);
            byte[] l_out_ = l_hsh_.ComputeHash(l_inp_);

            string l_pas_ = BitConverter.ToString(l_out_).Replace("-", string.Empty).Substring(0, 16).ToLower();



            // Does the hash of icoming password exist in hash table
            //_c_player q_ply_;= (from i_ply_ in s_ply_
            //                     where i_ply_.s_pas_ == l_pas_
            //                     select i_ply_).FirstOrDefault(); // Returns new _c_player() if no match

            return true;
        }

        /// <summary>
        /// يحسب ترتيب الخلية من إحداثياتها
        /// </summary>
        byte f_tondx_(byte[] p_crd_)
        {
            return (byte)((p_crd_[0] * 3) + p_crd_[1]);
        }

        /// <summary>
        /// يحسب احداثيات الخلية من ترتيبها
        /// </summary>
        byte[] f_tocrd_(byte p_ndx_)
        {
            byte l_row_ = (byte)Math.Floor((double)(p_ndx_ / 3));
            byte l_col_ = (byte)(p_ndx_ - (3 * l_row_));
            return new byte[] { l_col_, l_row_ };
        }

        /// <summary>
        /// هل الخلية ليها 2 جيران من نوع محدد
        /// </summary>
        Boolean f_neighbour_(byte p_cel_, byte[] p_lst_)
        {
            byte[] l_crd_ = f_tocrd_(p_cel_);

            // كام خلية في نفس الصف
            int q_col_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_cel_ &&
                          f_tocrd_(i_byt_)[0] == l_crd_[0]
                          select i_byt_).Count();

            if (q_col_ == 2) { return true; }

            // كام خلية في نفس العمود
            int q_row_ = (from i_byt_ in p_lst_
                          where
                          i_byt_ != p_cel_ &&
                          f_tocrd_(i_byt_)[1] == l_crd_[1]
                          select i_byt_).Count();

            if (q_row_ == 2) { return true; }

            // لو الخلية الفاضية في أحد الأركان
            byte[] l_crn_ = { 0, 2, 6, 8 }; // الأركان
            byte[] l_inv_ = { 8, 6, 2, 0 }; // الركن المقابل
            if (l_crn_.Contains(p_cel_))
            {
                byte l_ops_ = l_inv_[Array.IndexOf(l_crn_, p_cel_)];

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
        byte f_status_(byte p_tp1_, byte p_tp2_, int[] p_brd_)
        {
            List<byte> l_tp1_ = new List<byte>();
            List<byte> l_tp2_ = new List<byte>();

            for (byte i_ndx_ = 0; i_ndx_ < 9; i_ndx_++)
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
}
**/