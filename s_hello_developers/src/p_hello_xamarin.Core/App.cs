using MvvmCross.IoC;
using MvvmCross.ViewModels;
using p_hello_xamarin.Core.ViewModels.Home;

namespace p_hello_xamarin.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<HomeViewModel>();
        }
    }
}
