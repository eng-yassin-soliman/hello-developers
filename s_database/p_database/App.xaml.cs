using System.Diagnostics;
using System.Windows;

namespace p_database
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            while (true)
            {
                MainWindow l_man_ = new MainWindow();
                l_man_.ShowDialog();
                if (l_man_.s_ext_) { Process.GetCurrentProcess().Kill(); }
            }
        }
    }
}