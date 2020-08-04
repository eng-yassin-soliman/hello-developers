using System;
using System.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Threading.Tasks;
using Plugin.HybridWebView.Shared.Enumerations;
using System.Threading;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            b_web_.AddLocalCallback("v_my_csharp_function_", v_callback_);

            b_web_.ContentType = WebViewContentType.LocalFile;
            b_web_.Source = "HTML/home.html";
        }

        void v_callback_(string p_str_)
        {
            var l_str_ = HttpUtility.UrlDecode(p_str_);
            DisplayAlert("وصلني", l_str_, "OK");
        }

        protected override void OnAppearing()
        {
            v_page_loaded_();
        }

        async Task v_page_loaded_()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }

            var l_req_ = new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Best,
                Timeout = new TimeSpan(0, 0, 3)
            };

            var l_loc_ = await Geolocation.GetLocationAsync(l_req_);

            Thread.Sleep(1000);

            string l_lat_ = l_loc_.Latitude.ToString();
            string l_lng_ = l_loc_.Longitude.ToString();

            string l_msg_ = "Location is:" + l_lat_ + "," + l_lng_;

            string l_scr_ = "alert('" + l_msg_ + "');";

            b_web_.InjectJavascriptAsync(l_scr_);
        }
    }
}