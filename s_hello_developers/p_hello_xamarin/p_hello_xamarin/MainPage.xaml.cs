using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Http;
using System.Net.Sockets;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        } 

        [STAThread]
        void v_click_(object p_snd_, EventArgs p_arg_)
        {
            TcpClient l_tcp_ = new TcpClient();
            l_tcp_.Connect("192.168.4.1", 80);
            var l_stm_ = l_tcp_.GetStream();

            string[] l_sym_ = { "👆", "👈", "👉", "👇" };
            string[] l_cmd_ = { "up", "lt", "rt", "dn" };

            string l_txt_ = ((Button)p_snd_).Text;
            //string l_req_ =
            //    "GET /" + l_cmd_[Array.IndexOf(l_sym_, l_txt_)] + " HTTP/1.1\r\n" +
            //    "Host: 192.168.4.1\r\n" +
            //    "Connection: close\r\n\r\n";

            byte l_dta_ = l_txt_ == "up" ? (byte)0 : (byte)1;

            byte[] l_byt_ = { l_dta_ }; // Encoding.ASCII.GetBytes(l_req_);

            l_stm_.Write(l_byt_, 0, 1); // l_byt_.Length);

            //s_cln_.GetAsync("http://192.168.4.1/" + l_cmd_[Array.IndexOf(l_sym_, l_txt_)]).Wait();
        }
    }
}