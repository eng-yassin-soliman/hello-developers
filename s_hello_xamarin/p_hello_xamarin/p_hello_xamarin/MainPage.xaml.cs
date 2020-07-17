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