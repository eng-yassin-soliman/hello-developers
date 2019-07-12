using Dsafa.WpfColorPicker;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    public partial class _b_properties : UserControl
    {
        public _w_main s_man_;

        /// <summary>Stroke thickness</summary>
        public double s_thk_
        {
            get { return b_typ_.StrokeThickness; }
            set { b_typ_.StrokeThickness = value; }
        }

        /// <summary>Stroke dash type</summary>
        public DoubleCollection s_typ_
        {
            get { return b_typ_.StrokeDashArray; }
            set { b_typ_.StrokeDashArray = value; }
        }
        List<double[]> s_dsh_ = new List<double[]>();

        /// <summary>Stroke color</summary>
        public Brush s_str_
        {
            get { return b_str_.Fill; }
            set { b_str_.Fill = value; }
        }

        /// <summary>Figure fill brush</summary>
        public Brush s_fil_
        {
            get { return b_fil_.Fill; }
            set { b_fil_.Fill = value; }
        }

        /// <summary>Is closed figure?</summary>
        public bool s_cls_
        {
            get { return (bool)b_cls_.IsChecked; }
            set { b_cls_.IsChecked = value; }
        }

        public _b_properties()
        {
            InitializeComponent();

            // standard line types
            double[] l_sld_ = { };
            double[] l_hid_ = { 2, 2 };
            double[] l_cnt_ = { 5, 2, 1, 2 };
            double[] l_sec_ = { 5, 2, 2, 2, 2, 2 };

            s_dsh_.Add(l_sld_);
            s_dsh_.Add(l_hid_);
            s_dsh_.Add(l_cnt_);
            s_dsh_.Add(l_sec_);

            b_cls_.Checked += new RoutedEventHandler(v_close_);
            b_cls_.Unchecked += new RoutedEventHandler(v_close_);
        }

        /// <summary>Select color</summary>
        void v_color_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            Rectangle l_rec_ = (Rectangle)p_snd_;
            SolidColorBrush l_brh_ = (SolidColorBrush)l_rec_.Fill;
            Color l_col_ = l_brh_.Color;

            ColorPickerDialog l_dia_ = new ColorPickerDialog(l_col_);
            l_dia_.ShowDialog();

            if (l_dia_.DialogResult != true) { return; }

            SolidColorBrush l_brs_ = new SolidColorBrush(l_dia_.Color);
            if ((Rectangle)p_snd_ == b_str_)
            { s_str_ = l_brs_; }
            else
            { s_fil_ = l_brs_; }

            if (s_man_.s_pth_ == null) { return; }
            if ((Rectangle)p_snd_ == b_str_)
            { s_man_.s_pth_.Stroke = l_brs_; }
            else
            { s_man_.s_pth_.Fill = l_brs_; }
        }

        /// <summary>Select thickness and line type</summary>
        void v_type_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            _w_stroke l_dia_ = new _w_stroke();
            l_dia_.b_thk_.s_val_ = s_thk_;

            foreach (double[] i_typ_ in s_dsh_)
            {
                Line l_itm_ = new Line();
                l_dia_.b_typ_.Items.Add(l_itm_);
                l_itm_.StrokeDashArray = new DoubleCollection(i_typ_);
            }
            l_dia_.b_thk_.s_val_ = s_thk_;
            l_dia_.b_typ_.SelectedIndex = 0;

            l_dia_.ShowDialog();
            if (l_dia_.DialogResult != true) { return; }
            s_thk_ = l_dia_.b_thk_.s_val_;
            s_typ_ = new DoubleCollection(s_dsh_[l_dia_.b_typ_.SelectedIndex]);

            if (s_man_.s_pth_ == null) { return; }
            s_man_.s_pth_.StrokeThickness = s_thk_;
            s_man_.s_pth_.StrokeDashArray = s_typ_;
        }

        /// <summary>Open or close fiure</summary>
        void v_close_(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (s_man_.s_pth_ == null) { return; }
            s_man_.s_fig_.IsClosed = s_cls_;
        }

        /// <summary>When path list selection changed</summary>
        public void v_refresh_()
        {
            s_thk_ = s_man_.s_pth_.StrokeThickness;
            s_typ_ = s_man_.s_pth_.StrokeDashArray;
            s_str_ = s_man_.s_pth_.Stroke;
            s_fil_ = s_man_.s_pth_.Fill;
            s_cls_ = s_man_.s_fig_.IsClosed;
        }
    }
}