using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Forms;

namespace p_ArabiCAD
{
    /// <summary>
    /// Interaction logic for _w_figure.xaml
    /// </summary>
    public partial class _w_figure : Window
    {
        public bool s_add_ = false;

        public _w_figure()
        {
            InitializeComponent();
        }

        void v_pickcolor_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            ColorDialog l_col_ = new ColorDialog();
            l_col_.ShowDialog();
            ((Canvas)p_snd_).Background = new SolidColorBrush(Color.FromRgb(l_col_.Color.R, l_col_.Color.G, l_col_.Color.B));
        }

        void v_add_(object p_snd_, RoutedEventArgs p_arg_)
        {
            s_add_ = true;
            Close();
        }
    }
}