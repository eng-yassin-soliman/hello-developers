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
// using System.Windows.Forms;

namespace p_ArabiCAD
{
    /// <summary>
    /// Interaction logic for _w_main.xaml
    /// </summary>
    public partial class _w_main : Window
    {
        PathFigure s_fig_;
        public _e_status s_sts_ = _e_status.e_new_;
        public bool s_str_ = false; // هل تم اضافة نقطة البداية

        public _w_main()
        {
            InitializeComponent();

            b_cnv_.MouseUp += new MouseButtonEventHandler(v_point_);
            b_cnv_.MouseMove += new MouseEventHandler(v_move_);
        }

        // يضيف شكل
        void v_add_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            _w_figure l_dia_ = new _w_figure();  // choose color and title dialog box
            l_dia_.ShowDialog();
            if (!l_dia_.s_add_) { return; }

            s_sts_ = _e_status.e_1st_;
            s_str_ = false;

            b_lst_.Items.Add(l_dia_.b_nam_.Text);

            Path l_pth_ = new Path();
            l_pth_.Stroke = (SolidColorBrush)l_dia_.b_for_.Background;
            l_pth_.Fill = (SolidColorBrush)l_dia_.b_bck_.Background;
            l_pth_.StrokeThickness = 5;
            l_pth_.StrokeStartLineCap = PenLineCap.Round;
            l_pth_.StrokeEndLineCap = PenLineCap.Round;
            l_pth_.StrokeLineJoin = PenLineJoin.Round;
            b_cnv_.Children.Add(l_pth_);

            PathGeometry l_geo_ = new PathGeometry();
            l_pth_.Data = l_geo_;

            PathFigure l_fig_ = new PathFigure();
            l_geo_.Figures.Add(l_fig_);

            s_fig_ = l_fig_;

            b_pnt_.b_ttl_.Text = "نقطة البداية";
            b_pnt_.Visibility = Visibility.Visible;
            b_pnl_.Visibility = Visibility.Visible;

            b_val_.b_ttl_.Text = "نصف القطر";

            b_add_.Background = Brushes.Cornsilk;
            b_lin_.Background = Brushes.White;
            b_arc_.Background = Brushes.White;
        }

        void v_remove_(object p_snd_, RoutedEventArgs p_arg_)
        {
            int l_ndx_ = b_lst_.SelectedIndex;
            if (l_ndx_ == -1) { return; }

            b_lst_.Items.RemoveAt(l_ndx_);
            b_cnv_.Children.RemoveAt(l_ndx_);

            if (b_lst_.Items.Count == 0)
            {
                b_pnl_.Visibility = Visibility.Collapsed;
                b_pnt_.Visibility = Visibility.Collapsed;
                b_val_.Visibility = Visibility.Collapsed;

                s_sts_ = _e_status.e_new_;
                s_str_ = false;
            }
        }

        // add line to figure
        void v_lin_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            if (!s_str_) { return; }
            b_pnt_.b_ttl_.Text = "النقطة التالية";
            b_val_.Visibility = Visibility.Collapsed;
            s_sts_ = _e_status.e_lin_;

            b_add_.Background = Brushes.White;
            b_lin_.Background = Brushes.Cornsilk;
            b_arc_.Background = Brushes.White;
        }

        // add arc to current figure
        void v_arc_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            if (!s_str_) { return; }
            b_pnt_.b_ttl_.Text = "النقطة التالية";
            b_val_.Visibility = Visibility.Visible;
            s_sts_ = _e_status.e_arc_;

            b_add_.Background = Brushes.White;
            b_lin_.Background = Brushes.White;
            b_arc_.Background = Brushes.Cornsilk;
        }

        // لما تتحرك فوق لوحة الرسم يعرف مكانك فين ويكتب الاحداثيات
        void v_move_(object p_snd_, MouseEventArgs p_arg_)
        {
            Point l_pnt_ = p_arg_.GetPosition(b_cnv_);
            b_pnt_.b_xcr_.s_value_ = l_pnt_.X;
            b_pnt_.b_ycr_.s_value_ = l_pnt_.Y;
        }

        public enum _e_status
        {
            e_new_,
            e_1st_,
            e_lin_,
            e_arc_
        }

        // لما تدوس على لوحة الرسم يضيف النقطة للشكل
        void v_point_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            v_point_();
        }

        void v_point_(object p_snd_, RoutedEventArgs p_arg_)
        {
            v_point_();
        }

        void v_point_()
        {
            Point l_pnt_ = new Point(b_pnt_.b_xcr_.s_value_, b_pnt_.b_ycr_.s_value_);
            double l_rad_ = b_val_.b_val_.s_value_;

            switch (s_sts_)
            {
                case _e_status.e_new_:
                    return;

                case _e_status.e_1st_:
                    s_fig_.StartPoint = l_pnt_;
                    s_str_ = true;
                    // draw line by default
                    v_lin_(null, null);
                    break;

                case _e_status.e_lin_:
                    LineSegment l_lin_ = new LineSegment(l_pnt_, true);
                    s_fig_.Segments.Add(l_lin_);
                    break;

                default:
                    ArcSegment l_arc_ = new ArcSegment(l_pnt_, new Size(l_rad_, l_rad_), 0, false, SweepDirection.Clockwise, true);
                    s_fig_.Segments.Add(l_arc_);
                    break;
            }
        }

        void v_close_(object p_snd_, RoutedEventArgs p_arg_)
        {
            s_fig_.IsClosed = (bool)((CheckBox)p_snd_).IsChecked;
        }
    }
}