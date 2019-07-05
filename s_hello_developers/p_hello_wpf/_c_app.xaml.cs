using System.Windows;
using System;

namespace p_hello_wpf
{
    /// <summary>
    /// Interaction logic for _c_app.xaml  
    /// </summary>
    public partial class _c_app : Application
    {
        protected override void OnStartup(StartupEventArgs p_stp_)
        {
            base.OnStartup(p_stp_);

            MessageBox.Show("i started");

            Shutdown(0);

            return;
        }

        //void v_start_()
        //{
        //    // change _c_yassin to your class name, test your function with many values other than 7
        //    MessageBox.Show(_c_yassin.f_factorial_(7).ToString()); // 7 is arbitary test value
        //}
    }
}