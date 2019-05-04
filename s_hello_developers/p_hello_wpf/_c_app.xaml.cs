using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
// using p_hello_library;

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
            // change _c_yassin to your class name, test your function with many values other than 7
            // MessageBox.Show(_c_yassin.f_factorial_(7).ToString()); // 7 is arbitary test value
        }
    }
}