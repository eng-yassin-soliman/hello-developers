using Xamarin.Forms;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System;
using System.Text;
using Xam.Plugin.WebView.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace hello_hybrid
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        FormsWebView s_web_ = new FormsWebView();

        public MainPage()
        {
            InitializeComponent();

            //WebView.AddLocalCallback("test", (str) => Debug.WriteLine(str));
            //WebView.RemoveLocalCallback("test");

            b_pnl_.Children.Add(s_web_);
            s_web_.WidthRequest = 100;
            s_web_.HeightRequest = 100;
            s_web_.HorizontalOptions = LayoutOptions.FillAndExpand;
            s_web_.VerticalOptions = LayoutOptions.FillAndExpand;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Get the platform-specific resources url 
            _i_resources l_res_ = DependencyService.Get<_i_resources>();
            string l_url_ = l_res_.f_url_();

            s_web_.Source = l_url_;

            Permission[] l_per_ = { Permission.Camera };
            CrossPermissions.Current.RequestPermissionsAsync(l_per_).Wait();
            DisplayAlert("ok", "ok","ok");
        }
    }
}