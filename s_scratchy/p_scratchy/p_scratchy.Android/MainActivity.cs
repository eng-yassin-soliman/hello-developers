using Android.App;
using Android.Content.PM;
using Android.OS;
using Tesseract.Droid;
using XLabs.Ioc;
using Autofac;
using XLabs.Ioc.Autofac;
using Android.Content;
using Tesseract;
using Android.Runtime;

namespace p_scratchy.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.Register(c => this).As<Context>();
            containerBuilder.RegisterType<TesseractApi>()
                .As<ITesseractApi>()
                .WithParameter((pi, c) => pi.ParameterType == typeof(AssetsDeployment),
                (pi, c) => AssetsDeployment.OncePerInitialization);
            Resolver.SetResolver(new AutofacResolver(containerBuilder.Build()));

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}