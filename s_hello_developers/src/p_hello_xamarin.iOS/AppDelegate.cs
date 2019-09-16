using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace p_hello_xamarin.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
    }
}
