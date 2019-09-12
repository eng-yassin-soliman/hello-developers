using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.CurrentActivity;
using Plugin.Permissions;
using Xam.Plugin.WebView.Droid;

namespace hello_hybrid.Droid
{
    [Activity(Label = "hello hybrid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle p_bnd_)
        {
            base.OnCreate(p_bnd_);
            CrossCurrentActivity.Current.Init(this, p_bnd_);
            global::Xamarin.Forms.Forms.Init(this, p_bnd_);

            FormsWebViewRenderer.Initialize();
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(
            int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}