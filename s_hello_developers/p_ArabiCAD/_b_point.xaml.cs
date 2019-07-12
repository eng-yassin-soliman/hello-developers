using System.Windows;
using System.Windows.Controls;

namespace p_ArabiCAD
{
    public partial class _b_point : UserControl
    {
        public bool p_vld_ = true;

        public _b_point()
        {
            InitializeComponent();
            b_xcr_.TextChanged += new TextChangedEventHandler(v_update_);
        }

        // fire update event
        void v_update_(object p_snd_, TextChangedEventArgs p_arg_) { string l_str_ = ((TextBox)p_snd_).Text; }

        public Point s_val_
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