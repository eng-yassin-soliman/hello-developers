using p_mobile_calc.Services;
using p_mobile_calc.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p_mobile_calc
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
