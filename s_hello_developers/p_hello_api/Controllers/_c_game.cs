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
        public string s_ssn_ = "";      // Session id

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

            if (string.IsNullOrEmpty(q_ply_.s_pas_))
            { return new _c_player[] { new _c_player("كلمة المرور غير صحيحة", "", "") }; }

            if (q_ply_.s_los_ == 10)
            { return new _c_player[] { new _c_player("حظ سعيد المرة القادمة!", "", "") }; }

            // Set session
            q_ply_.s_nam_ = p_ply_.s_nam_;
            q_ply_.s_ssn_ = p_ply_.s_ssn_;
            q_ply_.s_clr_ = p_ply_.s_clr_;

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

            int l_nxt_ = (new Random()).Next(0, l_emp_.Count);
            q_ply_.s_srv_.Add(l_emp_[l_nxt_]);

        n_final_:
            StringBuilder l_str_ = new StringBuilder("");
            for (byte i_byt_ = 0; i_byt_ < 9; i_byt_++)
            {
                if (q_ply_.s_usr_.Contains(i_byt_)) { l_str_.Append("1"); }
                else if (q_ply_.s_srv_.Contains(i_byt_)) { l_str_.Append("2"); }
                else { l_str_.Append("0"); }
            }

            Regex l_rg1_ = new Regex("111|1...1...1|1....1....1|1..1..1");
            Regex l_rg2_ = new Regex("222|2...2...2|2....2....2|2..2..2");
            if (l_rg1_.Match(l_str_.ToString()).Success)        // Check user wins
            { q_ply_.s_win_ += 1; }

            else if (l_rg2_.Match(l_str_.ToString()).Success)   // Check server wins
            { q_ply_.s_los_ += 1; }

            else if (!l_emp_.Any())                             // Check boxes are full
            { }

            else
            { return s_ply_; }

            q_ply_.s_usr_.Clear();
            q_ply_.s_srv_.Clear();
            return s_ply_;
        }
    }
}