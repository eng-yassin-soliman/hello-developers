using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HelloWorld_2
{     /// (فريق الهبيدة)
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
    public partial class MainWindow : Window

    {
        double num1 = 0;
        double num2 = 0;
        string opr = "";

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Pls_Click(object sender, RoutedEventArgs e)
        {
            opr = "+";
            txt.Text = num1.ToString() + ("+");
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = (num1 * 10) + 1;
                txt.Text = num1.ToString();

            }
            else
            {
                num2 = (num2 * 10) + 1;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString(); ;
            }
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = (num1 * 10) + 2;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 2;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = (num1 * 10) + 3;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 3;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B4_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 4;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 4;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B5_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 5;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 5;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B6_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 6;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 6;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B7_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 7;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 7;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B8_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 8;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 8;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B9_Click(object sender, RoutedEventArgs e)
        {

            if (opr == "")
            {
                num1 = (num1 * 10) + 9;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 9;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void B0_Click(object sender, RoutedEventArgs e)
        {


            if (opr == "")
            {
                num1 = (num1 * 10) + 0;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 * 10) + 0;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            opr = "-";
            txt.Text = num1.ToString() + ("-");
        }

        private void Prod_Click(object sender, RoutedEventArgs e)
        {
            opr = "*";
            txt.Text = num1.ToString() + ("*");
        }

        private void Over_Click(object sender, RoutedEventArgs e)
        {
            opr = "/";
            txt.Text = num1.ToString() + ("/");
        }

        private void Eq_Click(object sender, RoutedEventArgs e)
        {
            switch (opr)
            {
                case ("+"):
                    txt.Text = (num1 + num2).ToString();
                    break;

                case ("-"):
                    txt.Text = (num1 - num2).ToString();
                    break;
                case ("*"):
                    txt.Text = (num1 * num2).ToString();
                    break;
                case ("/"):
                    if (num2 == 0)
                    {
                        MessageBox.Show("math error");
                        break;
                    }
                    else
                    {
                        txt.Text = (num1 / num2).ToString();
                        break;
                    }
                case ("^"):
                    txt.Text = Math.Pow(num1, num2).ToString();
                    break;
                case ("rem"):

                    txt.Text = (num1 % num2).ToString();
                    break;

            }




        }

        private void Grid_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Clrent_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = 0;
                txt.Text = "0";
            }

            else
            {
                num2 = 0;
                txt.Text = num1.ToString() + opr.ToString();
            }
        }

        private void Clr_Click(object sender, RoutedEventArgs e)
        {
            num1 = 0;
            num2 = 0;
            opr = "";
            txt.Text = "0";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = (num1 / 10);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (num2 / 10);
                txt.Text = num1.ToString();
            }
        }

        private void Chn_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 *= -1;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 *= -1;
                txt.Text = num1.ToString();
            }
        }

        private void Over2_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = (1 / num1);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = (1 / num2);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }

        }

        private void Sin1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = Math.Sin(Math.PI * num1 / 180.0);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Sin(Math.PI * num2 / 180.0);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Cos1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = Math.Cos(Math.PI * num1 / 180.0);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Cos(Math.PI * num2 / 180.0);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Tan1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = Math.Tan(Math.PI * num1 / 180.0);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Tan(Math.PI * num2 / 180.0);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Log1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = Math.Log(num1);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Log(num2);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Ln1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = Math.Round(Math.Log(num1));
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Round(Math.Log(num2));
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Power_Click(object sender, RoutedEventArgs e)
        {
            opr = "^";
            txt.Text = num1.ToString() + ("^");
        }

        private void Power2_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.Pow(num1, 2);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Pow(num2, 2);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Expon_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.Pow(Math.E, num1);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Pow(Math.E, num2);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Fatorial_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                double result = 1;
                while (num1 != 1)
                {
                    result = result * num1;
                    num1 = num1 - 1;
                }
                num1 = result;
            }
            else
            {

                double result = 1;
                while (num2 != 1)
                {
                    result = result * num1;
                    num2 = num2 - 1;
                }
                num2 = result;
            }
        }

        private void Power3_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.Pow(num1, 3);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Pow(num2, 3);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Present_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {
                num1 = num1 * 100;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = num2 * 100;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Root_Click(object sender, RoutedEventArgs e)
        {
            opr = "r";
            txt.Text = ("r") + num1.ToString();
        }

        private void Ex1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.E;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.E;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }


        private void Rem_Click(object sender, RoutedEventArgs e)
        {
            opr = "rem";
            txt.Text = num1.ToString() + ("rem");
        }

        private void Root2_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.Sqrt(num1);
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.Sqrt(num2);
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }

        private void Pi1_Click(object sender, RoutedEventArgs e)
        {
            if (opr == "")
            {

                num1 = Math.PI;
                txt.Text = num1.ToString();
            }
            else
            {
                num2 = Math.PI;
                txt.Text = num1.ToString() + opr.ToString() + num2.ToString();
            }
        }
    }
}