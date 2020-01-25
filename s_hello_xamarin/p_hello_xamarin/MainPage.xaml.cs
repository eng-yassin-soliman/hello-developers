using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using org.mariuszgromada.math.mxparser;
using Expression = org.mariuszgromada.math.mxparser.Expression;

namespace p_hello_xamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Appearing += v_resize_;
            SizeChanged += v_resize_;

            mXparser.enableCanonicalRounding();
        }

        void v_resize_(object p_snd_, EventArgs p_arg_)
        {
            Size l_siz_ = new Size(300, 475);
            double l_asp_ = 300.0 / 475.0;
            double l_wdt_ = 0;

            if (Device.Idiom == TargetIdiom.Desktop)
            {
                l_wdt_ = Height * l_asp_;
            }
            else // Mobile or tablet
            {
                if ((Width / Height) < l_asp_)
                { l_wdt_ = Width; }
                else
                { l_wdt_ = Height * l_asp_; }
            }

            double l_scl_ = l_wdt_ / 300.0;

            b_inp_.HeightRequest = 40.0 * l_scl_;
            b_out_.HeightRequest = 60.0 * l_scl_;

            b_inp_.FontSize = 16.0 * l_scl_;
            b_out_.FontSize = 20.0 * l_scl_;

            for (byte i_lbl_ = 2; i_lbl_ < b_grd_.Children.Count; i_lbl_ += 1)
            {
                Button l_lbl_ = (Button)b_grd_.Children[i_lbl_];
                l_lbl_.WidthRequest = 75.0 * l_scl_;
                l_lbl_.HeightRequest = 75.0 * l_scl_;
                l_lbl_.FontSize = 20.0 * l_scl_;
            }
        }

        void v_click_(object sender, EventArgs e)
        {
            Button l_btn_ = (Button)sender;

            switch (l_btn_.Text)
            {
                case "⇦":
                    if (!string.IsNullOrEmpty(b_inp_.Text))
                    { b_inp_.Text = b_inp_.Text.Substring(0, b_inp_.Text.Length - 1); }
                    break;

                case "AC":
                    b_inp_.Text = string.Empty;
                    b_out_.Text = "0";
                    break;

                case "√":
                    b_inp_.Text = b_inp_.Text + "sqrt(";
                    break;

                case "×":
                    b_inp_.Text = b_inp_.Text + "*";
                    break;

                case "÷":
                    b_inp_.Text = b_inp_.Text + "/";
                    break;

                default:
                    b_inp_.Text = b_inp_.Text + l_btn_.Text;
                    break;
            }

            v_calculate_();
        }

        void v_calculate_()
        {
            if (string.IsNullOrEmpty(b_inp_.Text))
            {
                b_out_.Text = "0";
                return;
            }

            Expression l_exp_ = new Expression(b_inp_.Text);
            b_out_.Text = l_exp_.calculate().ToString();
        }
    }
}