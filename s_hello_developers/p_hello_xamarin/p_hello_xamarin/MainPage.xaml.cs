using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using Xamarin.Forms;

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
            b_clk_.Clicked += v_capture_;
        }

        async void v_capture_(object p_snd_, EventArgs p_arg_)
        {
            await CrossMedia.Current.Initialize();
            var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { });
            await DisplayAlert("الكاميرا", "ok00", "تم");
        }
    }
}