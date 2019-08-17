using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace p_hello_api
{
    public class _c_security
    {
        // A 24 bytes array for encryption keys (16 + 8)
        public static byte [] s_key_ = Encoding.UTF8.GetBytes( "Ms57gUi3u8jG8Fg79vDJX2C8");
        // A 8 bytes padding for integrity check
        public static byte[] s_pad_ = Encoding.UTF8.GetBytes("12345678");


        public static byte [] f_encrypt_( byte [] p_msg_)
        {
            TripleDESCryptoServiceProvider l_tds_ = new TripleDESCryptoServiceProvider();
            l_tds_.Key = s_key_.Take(16).ToArray();
            // A 16 bytes Key
            l_tds_.IV = s_key_.Skip(16).ToArray();
            // An 8 bytes IV
            l_tds_.Mode = CipherMode.ECB;
            l_tds_.Padding = PaddingMode.PKCS7;
            ICryptoTransform l_enc_ = l_tds_.CreateEncryptor();
            // Notice: (En-cryptor!)
            List<byte> l_inp_ = new List<byte>();
            l_inp_.AddRange(s_pad_);
            // Padding for integrity check
            l_inp_.AddRange(p_msg_);
            // Encrypt
            byte [] l_out_ = l_enc_.TransformFinalBlock(l_inp_.ToArray(), 0, l_inp_.Count);
            l_tds_.Clear();
            return l_out_;
        }



        public static byte[] f_decrypt_(byte [] p_cpr_)
        {
            TripleDESCryptoServiceProvider l_tds_ = new TripleDESCryptoServiceProvider();
            l_tds_.Key = s_key_.Take(16).ToArray();
            // A 16 bytes Key
            l_tds_.IV = s_key_.Skip(16).ToArray();
            // An 8 bytes IV
            l_tds_.Mode = CipherMode.ECB;
            l_tds_.Padding = PaddingMode.PKCS7;
            ICryptoTransform l_dec_ = l_tds_.CreateDecryptor();
            // Notice: (En-cryptor!)
            // Decrypt
            byte [] l_out_ = l_dec_.TransformFinalBlock(p_cpr_, 0, p_cpr_.Length);
            l_tds_.Clear();
            // Check integrity
            if (!l_out_.Take(8).ToArray().SequenceEqual(s_pad_))
            {
                return new byte[] { };
            }
            return l_out_.Skip(8).ToArray();
            // Remove padding
        }
        public static byte[] f_hash_(byte[] p_inp_)
        {
            SHA256 l_hsh_ = SHA256.Create();
            byte [] l_out_ = l_hsh_.ComputeHash(p_inp_);
            return l_out_.Take(8).ToArray();
        }
    }
}
