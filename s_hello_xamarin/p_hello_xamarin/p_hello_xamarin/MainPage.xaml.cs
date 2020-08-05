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
        double[] s_loc_ = new double[] { 0, 0, 0, 0 };

        public MainPage()
        {
            InitializeComponent();

            b_web_.AddLocalCallback("v_send_text_", v_send_text_);
            b_web_.AddLocalCallback("v_get_location_", v_get_location_);

            b_web_.ContentType = WebViewContentType.LocalFile;
            b_web_.Source = "HTML/home.html";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            v_set_location_async_();
        }

        void v_send_text_(string p_str_) 
        {
            string l_str_ = HttpUtility.UrlDecode(p_str_);
            DisplayAlert("وصلني", p_str_, "OK");
        }

        void v_get_location_(string p_str_)
        { v_get_location_async_(); }

        async Task v_set_location_async_()
        {
            while (true)
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                { status = await Permissions.RequestAsync<Permissions.LocationAlways>(); }

                var l_req_ = new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Best,
                    Timeout = new TimeSpan(0, 0, 3)
                };

                var l_loc_ = await Geolocation.GetLocationAsync(l_req_);

                s_loc_[0] = l_loc_.Latitude;
                s_loc_[1] = l_loc_.Longitude;
                s_loc_[2] = (double)l_loc_.Accuracy;
                s_loc_[3] = DateTime.Now.Second;

                await Task.Delay(1000);
            }
        }

        async Task v_get_location_async_()
        {
            string l_msg_ = "Location is:" + string.Join(", ", s_loc_);

            string l_scr_ = "f_show_loc_('" + l_msg_ + "');";
            await b_web_.InjectJavascriptAsync(l_scr_);
        }
    }
}