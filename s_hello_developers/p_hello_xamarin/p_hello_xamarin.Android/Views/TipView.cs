using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;
using p_hello_xamarin.ViewModels;
using ns_droid_ = p_hello_xamarin.Droid;

namespace TipCalc.UI.Droid.Views
{
    [Activity(Label = "Tip Calculator", MainLauncher = true)]
    public class TipView : MvxActivity<_c_mainview>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(ns_droid_::Resource.Layout.TipView);
        }
    }
}