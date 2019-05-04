using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace p_ArabiCAD
{
    class _b_double : TextBox
    {
        public bool p_vld_ = true;

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
                p_vld_ = true; Background = new SolidColorBrush(Colors.White);
            }
            catch
            {
                p_vld_ = false; Background = new SolidColorBrush(Colors.LightPink);
            }
        }

        public double s_value_
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