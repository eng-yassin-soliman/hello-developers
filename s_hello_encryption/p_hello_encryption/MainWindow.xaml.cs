using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows;
using System.Globalization;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace p_hello_encryption
{
    public partial class MainWindow : Window
    {
        // Symmetric encryption
        public byte[] s_key_ = Encoding.UTF8.GetBytes("Ms57gUi3u8jG8Fg79vDJX2C8");

        // A 8 bytes padding for integrity check
        public byte[] s_pad_ = Encoding.UTF8.GetBytes("9F4834KE");

        TripleDESCryptoServiceProvider s_tds_;
        RSA s_rsa_ = RSA.Create();

        public MainWindow()
        {
            InitializeComponent();

            // Symmetric algorithm
            s_tds_ = new TripleDESCryptoServiceProvider();
            s_tds_.Key = s_key_.Take(16).ToArray(); // A 16 bytes Key
            s_tds_.IV = s_key_.Skip(16).ToArray();  // An 8 bytes IV

            s_tds_.Mode = CipherMode.ECB;
            s_tds_.Padding = PaddingMode.PKCS7;

            // Asymmetric algorithm
            string l_dir_ = "D:\\Github\\eng-yassin-soliman\\hello-developers\\s_hello_encryption\\p_hello_encryption\\rsa\\";
            byte[] l_pub_ = Convert.FromBase64String(File.ReadAllText(l_dir_ + "pub.txt").Replace("/r/n",""));
            byte[] l_pri_ = Convert.FromBase64String(File.ReadAllText(l_dir_ + "pri.txt").Replace("/r/n", ""));

            s_rsa_.ImportSubjectPublicKeyInfo(l_pub_, out _);
            s_rsa_.ImportPkcs8PrivateKey(l_pri_, out _);
        }

        #region "Symmetric"
        void v_symmetric_enc_(object p_snd_, RoutedEventArgs p_arg_)
        {
            ICryptoTransform l_enc_ = s_tds_.CreateEncryptor(); // Notice: (En-cryptor!)
            List<byte> l_inp_ = new List<byte>();
            l_inp_.AddRange(s_pad_);                            // Padding for integrity check
            l_inp_.AddRange(Encoding.UTF8.GetBytes(b_inp_.Text));

            //// Encrypt
            byte[] l_out_ = l_enc_.TransformFinalBlock(l_inp_.ToArray(), 0, l_inp_.Count);
            b_out_.Text = BitConverter.ToString(l_out_);
        }

        void v_symmetric_dec_(object p_snd_, RoutedEventArgs p_arg_)
        {
            ICryptoTransform l_dec_ = s_tds_.CreateDecryptor(); // Notice: (De-cryptor!)

            // hex decode it to byte array
            string[] l_hxs_ = b_out_.Text.Split("-");
            byte[] l_cph_ = (from i_hex_ in l_hxs_
                             select byte.Parse(i_hex_, NumberStyles.HexNumber)).ToArray();

            // Decrypt
            byte[] l_out_ = l_dec_.TransformFinalBlock(l_cph_, 0, l_cph_.Length);

            // Check integrity
            if (!l_out_.Take(8).ToArray().SequenceEqual(s_pad_))
            {
                MessageBox.Show("Invalid input");
                return;
            }

            b_inp_.Text = Encoding.UTF8.GetString(l_out_.Skip(8).ToArray()); // Remove padding
        }
        #endregion

        #region "Asymmetric"
        void v_asymmetric_enc_(object p_snd_, RoutedEventArgs p_arg_)
        {
            byte[] l_inp_ = Encoding.UTF8.GetBytes(b_inp_.Text);
            byte[] l_out_ = s_rsa_.Encrypt(l_inp_, RSAEncryptionPadding.OaepSHA256);
            b_out_.Text = BitConverter.ToString(l_out_);
        }

        void v_asymmetric_dec_(object p_snd_, RoutedEventArgs p_arg_)
        {
            string[] l_hxs_ = b_out_.Text.Split("-");
            byte[] l_cph_ = (from i_hex_ in l_hxs_
                             select byte.Parse(i_hex_, NumberStyles.HexNumber)).ToArray();

            byte[] l_out_ = s_rsa_.Decrypt(l_cph_, RSAEncryptionPadding.OaepSHA256);
            b_inp_.Text = Encoding.UTF8.GetString(l_out_);
        }
        #endregion

        #region "Hashing"
        byte[] f_hash_() 
        {
            SHA256 l_hsh_ = SHA256.Create();
            return l_hsh_.ComputeHash(Encoding.UTF8.GetBytes(b_inp_.Text));
        }

        void v_hash_(object p_snd_, RoutedEventArgs p_arg_)
        {
            byte[] l_out_ = f_hash_();
            b_out_.Text = BitConverter.ToString(l_out_);
        }

        void v_verify_(object p_snd_, RoutedEventArgs p_arg_) 
        {
            byte[] l_out_ = f_hash_();
            if (b_out_.Text != BitConverter.ToString(l_out_))
            {
                MessageBox.Show("Invalid input");
                return;
            };

            MessageBox.Show("Ok");
        }
        #endregion
    }
}