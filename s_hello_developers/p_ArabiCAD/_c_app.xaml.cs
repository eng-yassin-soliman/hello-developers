using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace p_ArabiCAD
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
            MessageBox.Show("ok001");
        }
    }
}