using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using org.arbweb.xam.ui;

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
            v_permit_async_();
        }

        async Task v_permit_async_()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationAlways>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationAlways>();
            }

            var b_web_ = new _c_hybridwebview { Uri = "home.html" };
            Content = b_web_;
            b_web_.HorizontalOptions = LayoutOptions.Fill;
            b_web_.VerticalOptions = LayoutOptions.Fill;

            //b_web_.RegisterAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));
        }
    }
}