using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace p_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //u_btn += 
        }

        private void u_btn_Click(object sender, RoutedEventArgs e)
        {
            var l_mm1 = new MemoryStream();
            var l_wrt = new StreamWriter(l_mm1, Encoding.UTF8);
            l_wrt.Write("hello world");
            l_wrt.Flush();
            l_mm1.Position = 0;

            var l_mm2 = new MemoryStream();
            l_mm1.CopyTo(l_mm2);
            l_mm1.Position = 0;
            l_mm2.Position = 0;

            var l_rdr = new StreamReader(l_mm2, Encoding.UTF8);
            u_txt.Text = l_rdr.ReadToEnd();
        }
    }
}