using Unosquare.Labs.EmbedIO;
using Unosquare.Labs.EmbedIO.Modules;

using System.Reflection;
using System.Resources;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace hello_hybrid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Task.Factory.StartNew(async () =>
            {
                using (var l_srv_ = new WebServer("http://localhost:80"))
                {
                    l_srv_.RegisterModule(new LocalSessionModule());
                    l_srv_.Module<StaticFilesModule>().UseRamCache = true;
                    l_srv_.Module<StaticFilesModule>().DefaultExtension = ".html";
                    l_srv_.Module<StaticFilesModule>().DefaultDocument = "index.html";
                    await l_srv_.RunAsync();
                }
            });
        }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}