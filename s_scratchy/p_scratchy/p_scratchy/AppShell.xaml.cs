using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace p_scratchy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }
    }
}