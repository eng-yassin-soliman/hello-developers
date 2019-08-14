using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using p_hello_api.DAL;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace p_hello_api.Controllers
{
    [ApiController]
    [Route("login")]
    public class _c_login : Controller
    {
        [HttpPost]
        [Route("login")]
        public string f_login_(_c_member p_mem_)
        {
            string l_rtr_ = string.Empty; // Message to return
            string l_pas_ = f_hash_(p_mem_.s_pas_);

            _c_dal l_dal_ = new _c_dal();
            l_dal_.f_open_();

            _c_member[] q_mem_ = (from _c_member i_mem_ in l_dal_.t_members
                                  where
                                  i_mem_.s_nam_ == p_mem_.s_nam_ &&
                                  i_mem_.s_pas_ == l_pas_
                                  select i_mem_).ToArray();

            if (!q_mem_.Any())
            {
                l_rtr_ = "خطأ في اسم الدخول أو كلمة المرور";
                goto n_final_;
            }
            _c_member l_mem_ = q_mem_.First();

            // Send the encrypted ID to client in order to use instead of name and password
            HttpContext.Response.Cookies.Append("c_uid_", l_mem_.s_uid_.ToString());
            HttpContext.Response.Cookies.Append("c_tkn_", f_encrypt_(l_mem_.s_uid_.ToString()));
            l_rtr_ = "1";   // Login successful!

        n_final_:
            l_dal_.f_close_(true);
            return l_rtr_;
        }

        [HttpPost]
        [Route("signup")]
        public string f_signup_(_c_member p_mem_)
        {
            if (p_mem_.s_nam_ == null | p_mem_.s_pas_.Length < 6 | p_mem_.s_pas_.Length > 30)
            {
                return "اسم الدخول يجب ألا يقل عن 3 أحرف ولا يزيد عن 30 حرف";
            }

            if (p_mem_.s_pas_ == null | p_mem_.s_pas_.Length < 6 | p_mem_.s_pas_.Length > 30)
            {
                return "كلمة المرور يجب ألا تقل عن 6 أحرف ولا تزيد عن 30 حرف";
            }

            // Hash the password
            string l_hsh_ = f_hash_(p_mem_.s_pas_);

            _c_dal l_dal_ = new _c_dal();
            l_dal_.f_open_();

            _c_member l_mem_ = new _c_member(p_mem_.s_nam_, l_hsh_);
            l_dal_.Entry(l_mem_).State = EntityState.Added;

            if (!l_dal_.f_save_())
            {
                l_dal_.f_close_(true);
                return l_dal_.s_err_;
            }

            if (!l_dal_.f_close_(true))
            {
                return "Error";
            }

            return "ok";
        }

        string f_hash_(string p_inp_)
        {
            SHA256 l_hsh_ = SHA256.Create();
            byte[] l_inp_ = Encoding.UTF8.GetBytes(p_inp_);
            byte[] l_out_ = l_hsh_.ComputeHash(l_inp_);
            return BitConverter.ToString(l_out_).Replace("-", string.Empty).Substring(0, 16).ToLower();
        }

        // A 24 bytes array for encryption keys (16 + 8)
        public static byte[] s_key_ = Encoding.UTF8.GetBytes("Ms57gUi3u8jG8Fg79vDJX2C8");

        public static string f_encrypt_(string p_inp_)
        {
            TripleDESCryptoServiceProvider l_tds_ = new TripleDESCryptoServiceProvider();
            l_tds_.Key = s_key_.Take(16).ToArray();                         // A 16 bytes Key
            l_tds_.IV = s_key_.Skip(16).ToArray();                          // An 8 bytes IV
            l_tds_.Mode = CipherMode.ECB;
            l_tds_.Padding = PaddingMode.PKCS7;
            ICryptoTransform l_enc_ = l_tds_.CreateEncryptor();             // Notice: (En-cryptor!)

            byte[] l_inp_ = Encoding.UTF8.GetBytes("12345678" + p_inp_);    // Pad string for integrity check
            // Encrypt
            byte[] l_out_ = l_enc_.TransformFinalBlock(l_inp_, 0, l_inp_.Length);
            l_tds_.Clear();
            return Convert.ToBase64String(l_out_);                          // Encode encrypted bytes to string
        }

        public static string f_decrypt_(string p_inp_)
        {
            TripleDESCryptoServiceProvider l_tds_ = new TripleDESCryptoServiceProvider();
            l_tds_.Key = s_key_.Take(16).ToArray();                         // A 16 bytes Key
            l_tds_.IV = s_key_.Skip(16).ToArray();                          // An 8 bytes IV
            l_tds_.Mode = CipherMode.ECB;
            l_tds_.Padding = PaddingMode.PKCS7;
            ICryptoTransform l_dec_ = l_tds_.CreateDecryptor();             // Notice: (De-cryptor!)

            byte[] l_inp_ = Convert.FromBase64String(p_inp_);               // Decode string to bytes
            // Decrypt
            byte[] l_out_ = l_dec_.TransformFinalBlock(l_inp_, 0, l_inp_.Length);
            l_tds_.Clear();
            return Encoding.UTF8.GetString(l_out_).Substring(8);            // Remove padding
        }
    }
}