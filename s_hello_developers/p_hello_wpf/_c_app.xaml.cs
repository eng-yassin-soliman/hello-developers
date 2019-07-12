using System.Windows;

namespace p_hello_wpf
{
    /// <summary>
    /// Interaction logic for _c_app.xaml  
    /// </summary>
    public partial class _c_app : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            v_start_();
            Shutdown(0);
        }

        void v_start_()
        {
            _w_main l_man_ = new _w_main();
            l_man_.ShowDialog();
        }
    }
}