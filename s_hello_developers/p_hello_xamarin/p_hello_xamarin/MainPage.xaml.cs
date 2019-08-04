using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Net.Http;
using ModernHttpClient;
using System.Net.Sockets;

namespace p_hello_xamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        HttpClient s_cln_ = new HttpClient(new NativeMessageHandler());
        [STAThread]
        void v_click_(object p_snd_, EventArgs p_arg_)
        {
            TcpClient l_tcp_ = new TcpClient();
            l_tcp_.Connect("192.168.4.1", 80);
            var l_stm_ = l_tcp_.GetStream();

            string[] l_sym_ = { "👆", "👈", "👉", "👇" };
            string[] l_cmd_ = { "up", "lt", "rt", "dn" };

            string l_txt_ = ((Button)p_snd_).Text;
            string l_req_ =
                "GET /" + l_cmd_[Array.IndexOf(l_sym_, l_txt_)] + " HTTP/1.1\r\n" +
                "Host: 192.168.4.1:80\r\n" +
                "\r\n";
            byte[] l_byt_ = Encoding.ASCII.GetBytes(l_req_);
            l_stm_.Write(l_byt_, 0, l_byt_.Length);

            l_tcp_.Close();

            //s_cln_.GetAsync("http://192.168.4.1/" + l_cmd_[Array.IndexOf(l_sym_, l_txt_)]).Wait();
        }
    }
}