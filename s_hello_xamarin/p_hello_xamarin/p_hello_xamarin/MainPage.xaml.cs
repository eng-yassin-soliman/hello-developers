using System;
using System.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Threading.Tasks;
using Plugin.HybridWebView.Shared.Enumerations;

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
            DisplayAlert("Message From JS", l_str_, "OK");
        }

        protected override void OnAppearing()
        {
            System.Diagnostics.Debug.WriteLine($"Got local callback: {"p_str_ 123456789"}");
            v_page_loaded_();
        }

        async Task v_page_loaded_()
        {
            return;

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
        }
    }
}