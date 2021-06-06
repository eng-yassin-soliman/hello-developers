using p_mobile_calc.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace p_mobile_calc.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}