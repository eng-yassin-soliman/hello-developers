using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Essentials;
// using org.arbweb.xam.ui;
using Xamarin.Forms;
using Plugin.HybridWebView.Shared;
using Plugin.HybridWebView.Shared.Enumerations;

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
            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }

            var location = await Geolocation.GetLastKnownLocationAsync();
            b_acc_.Text = location.Accuracy.ToString();
        }
    }
}