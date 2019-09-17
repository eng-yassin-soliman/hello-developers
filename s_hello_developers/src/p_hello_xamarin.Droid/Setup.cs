using Android.App;
using Java.Lang;
using MvvmCross.Forms.Platforms.Android.Core;
using System.Runtime.InteropServices;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace p_hello_xamarin.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
    }
}