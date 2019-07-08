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

namespace p_hello_cad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            for (int i_ndx_ = 0; i_ndx_ < 4; i_ndx_++)
            {
                TextBlock l_txt_ = new TextBlock
                {
                    Margin = new Thickness(5),

                    Padding = new Thickness(5),

                    Text =
                    "القيمة رقم" +
                    (i_ndx_ + 1).ToString(),

                    HorizontalAlignment = HorizontalAlignment.Right
                };

                TextBox l_txb_ = new TextBox
                {
                    Padding = new Thickness(5),
                    Margin = new Thickness(10,0,10,5)
                };

                b_pnl_.Children.Add(l_txt_);
                b_pnl_.Children.Add(l_txb_);
            }
        }

        Point f_pnt_(int p_int_)
        {
            TextBox l_txb_ = (TextBox)b_pnl_.Children[p_int_];
            string[] l_crd_ = l_txb_.Text.Split(",".ToArray());

            double l_xcr_ = 0;
            double l_ycr_ = 0;

            try
            {
                l_xcr_ = double.Parse(l_crd_[0]);
                l_ycr_ = double.Parse(l_crd_[1]);
            }
            catch (Exception p_exp_) { }

            return new Point(l_xcr_, l_ycr_);
        }

        void v_draw_(object p_snd_, EventArgs p_arg_)
        {
            b_fig_.Segments.Clear();

            b_fig_.StartPoint = f_pnt_(1);

            b_fig_.Segments.Add(new LineSegment(
                f_pnt_(3), true));

            b_fig_.Segments.Add(new LineSegment(
                f_pnt_(5), true));

            b_fig_.Segments.Add(new LineSegment(
                f_pnt_(7), true));
        }
    }
}