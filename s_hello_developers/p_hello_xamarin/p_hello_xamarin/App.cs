using MvvmCross;
using MvvmCross.ViewModels;
using p_hello_xamarin.Services;
using p_hello_xamarin.ViewModels;

namespace p_hello_xamarin
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.IoCProvider.RegisterType<_i_helloserv, _c_helloserv>();

            RegisterAppStart<_c_mainview>();
        }
    }
}