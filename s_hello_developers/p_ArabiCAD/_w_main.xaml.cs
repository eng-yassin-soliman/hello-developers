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

namespace p_ArabiCAD
{
    /// <summary>
    /// Interaction logic for _w_main.xaml
    /// </summary>
    /// 

    public partial class _w_main : Window
    {
        public _b_point s_pos_ = new _b_point();

        public _w_main()
        {
            InitializeComponent();

            b_cnv_.MouseUp += new MouseButtonEventHandler(v_click_);
            b_cnv_.MouseMove += new MouseEventHandler(v_move_);
        }

        void v_add_()
        {

        }

        void v_remove_()
        {

        }

        void v_move_(object p_snd_, MouseEventArgs p_arg_)
        {
            Point l_pnt_ = p_arg_.GetPosition(b_cnv_);
            b_pnt_.b_xcr_.s_value_ = l_pnt_.X;
            b_pnt_.b_ycr_.s_value_ = l_pnt_.Y;
        }

        void v_click_(object p_snd_, MouseButtonEventArgs p_arg_)
        {

        }
    }
}