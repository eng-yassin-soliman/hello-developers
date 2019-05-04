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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    /// <summary>
    /// Interaction logic for _b_point.xaml
    /// </summary>
    public partial class _b_point : UserControl
    {
        public bool p_vld_ = true; 

        public _b_point()
        {
            InitializeComponent();
            b_xcr_.TextChanged += new TextChangedEventHandler(v_update_);
        }

        public void v_show_()
        {

        }

        void v_update_(object p_snd_, TextChangedEventArgs p_arg_)
        {
            string l_str_ = ((TextBox)p_snd_).Text;

        }

        public Point s_point_
        {
            get
            {
                double.TryParse(b_xcr_.Text, out double l_xcr_);
                double.TryParse(b_ycr_.Text, out double l_ycr_);
                return new Point(l_xcr_, l_ycr_);
            }

            set
            {
                b_xcr_.Text = value.X.ToString();
                b_ycr_.Text = value.Y.ToString();
            }
        }
    }
}