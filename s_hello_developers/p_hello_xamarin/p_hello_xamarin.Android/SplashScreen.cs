using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;
using ns_droid_ = p_hello_xamarin.Droid;

namespace p_hello_xamarin.Android
{
    [Activity(
        MainLauncher = true,
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(ns_droid_:: Resource.Layout.SplashScreen)
        { }
    }
}