using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using p_hello_xamarin.Core.ViewModels.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p_hello_xamarin.UI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = true)]
    public partial class HomePage : MvxContentPage<HomeViewModel>
    {
        public HomePage()
        {
            InitializeComponent();

            b_btn_.Clicked += v_takepic_;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                navigationPage.BarTextColor = Color.White;
                navigationPage.BarBackgroundColor = (Color)Application.Current.Resources["PrimaryColor"];
            }
        }

        void v_takepic_(object p_snd_, EventArgs p_arg_)
        {
            DisplayAlert("arbweb.com", "ok000", "Cancel");
        }
    }
}