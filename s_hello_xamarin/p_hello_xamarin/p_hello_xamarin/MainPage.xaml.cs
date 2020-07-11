using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using System;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        
        protected override void OnAppearing()
        {
            v_getlocation_async_();
        }

        async Task v_getlocation_async_()
        {
            await DisplayAlert("", "started", "cancel");

            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }

            await DisplayAlert("", "acquiring location", "cancel");

            var l_req_ = new GeolocationRequest
            {
                DesiredAccuracy = GeolocationAccuracy.Best,
                Timeout = new TimeSpan(0, 0, 3)
            };
            var l_loc_ = await Geolocation.GetLocationAsync(l_req_);

            await DisplayAlert("", "location acquired", "cancel");

            b_lat_.Text = l_loc_.Latitude.ToString();
            b_lng_.Text = l_loc_.Longitude.ToString();
            b_acc_.Text = l_loc_.Accuracy.ToString();

            b_alt_.Text = l_loc_.Altitude.ToString();
            b_aac_.Text = l_loc_.VerticalAccuracy.ToString();
        }
    }
}