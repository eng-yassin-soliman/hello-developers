using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace p_ArabiCAD
{
    class _b_double : TextBox
    {
        public bool s_vld_ = true;

        public _b_double()
        {
            Width = 80; Text = "0"; TextAlignment = TextAlignment.Right;
            Margin = new Thickness(5); Padding = new Thickness(5);
        }

        protected override void OnTextChanged(TextChangedEventArgs p_arg_)
        {
            base.OnTextChanged(p_arg_);

            try
            {
                double.Parse(Text);
                s_vld_ = true; Background = Brushes.White;
            }
            catch
            {
                s_vld_ = false; Background = Brushes.LightPink;
            }
        }

        public double s_val_
        {
            get
            {
                double.TryParse(Text, out double p_dbl_);
                return p_dbl_;
            }
            set
            {
                Text = value.ToString("0.0000");
            }
        }
    }
}