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

namespace HelloWorld_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Know if the button is clicked
            sum.Click += f_sum;
            sub.Click += f_sub;
            mul.Click += f_mul;
            div.Click += f_div;
            clr.Click += f_clr;

            sin.Click += f_sin;
            cos.Click += f_cos;
            tan.Click += f_tan;
            ln.Click += f_ln;
            log.Click += f_log;


        }

        double p_num_1;
        double p_num_2;
        double p_res;
        bool p_num1_number;
        bool p_num2_number;
        bool p_AllNumbers;
        double p_TL_res1;
        double p_TL_res2;
        bool p_FT1;
        bool p_FT2;
        const double c_PI = Math.PI / 180;


        public bool IsNumber()
        {
            p_num1_number = double.TryParse(num_1.Text, out p_num_1);
            p_num2_number = double.TryParse(num_2.Text, out p_num_2);
            if (p_num1_number == true && p_num2_number == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsNum1Number()
        {
            p_num1_number = double.TryParse(num_1.Text, out p_num_1);
            if (p_num1_number == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsNum2Number()
        {
            p_num2_number = double.TryParse(num_2.Text, out p_num_2);
            if (p_num2_number == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ForbidenTan(double p_test)
        {
            //p_test = p_test;
            if (p_test % 90 == 0 && p_test % 180 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Normal Operations
        void f_sum(object sender, RoutedEventArgs e)
        {
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_res = p_num_1 + p_num_2;
                res.Text = p_res.ToString();
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }
        void f_sub(object sender, RoutedEventArgs e)
        {
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_res = p_num_1 - p_num_2;
                res.Text = p_res.ToString();
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }
        void f_mul(object sender, RoutedEventArgs e)
        {
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_res = p_num_1 * p_num_2;
                res.Text = p_res.ToString();
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }
        void f_div(object sender, RoutedEventArgs e)
        {
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                if (p_num_2 == 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_res = Math.Round(p_num_1 / p_num_2, 5);
                    res.Text = p_res.ToString();
                }
            }
            else
            {
                res.Text = "Syntax Error";
            }



        }

        //Clear Screen
        void f_clr(object sender, RoutedEventArgs e)
        {
            num_1.Text = "";
            num_2.Text = "";
        }


        //Tring Functions
        void f_sin(object sender, RoutedEventArgs e)
        {
            p_num1_number = this.IsNum1Number();
            p_num2_number = this.IsNum2Number();
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_TL_res1 = Math.Sin(c_PI * p_num_1);
                p_TL_res1 = Math.Round(p_TL_res1, 3);
                p_TL_res2 = Math.Sin(c_PI * p_num_2);
                p_TL_res2 = Math.Round(p_TL_res2, 3);
                res.Text = "Sin(" + p_num_1 + ") =" + p_TL_res1 + "\n Sin(" + p_num_2 + ")=" + p_TL_res2;
            }
            else if (p_num1_number == true && p_num2_number == false)
            {
                p_TL_res1 = Math.Sin(c_PI * p_num_1);
                p_TL_res1 = Math.Round(p_TL_res1, 3);
                res.Text = "Sin(" + p_num_1 + ") =" + p_TL_res1;
            }
            else if (p_num2_number == true && p_num1_number == false)
            {
                p_TL_res2 = Math.Sin(c_PI * p_num_2);
                p_TL_res2 = Math.Round(p_TL_res2, 3);
                res.Text = "Sin(" + p_num_2 + ") =" + p_TL_res2;
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }

        void f_cos(object sender, RoutedEventArgs e)
        {
            p_num1_number = this.IsNum1Number();
            p_num2_number = this.IsNum2Number();
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_TL_res1 = Math.Cos(c_PI * p_num_1);
                p_TL_res1 = Math.Round(p_TL_res1, 3);
                p_TL_res2 = Math.Cos(c_PI * p_num_2);
                p_TL_res2 = Math.Round(p_TL_res2, 3);
                res.Text = "Cos(" + p_num_1 + ") =" + p_TL_res1 + "\n Cos(" + p_num_2 + ")=" + p_TL_res2;
            }
            else if (p_num1_number == true && p_num2_number == false)
            {
                p_TL_res1 = Math.Sin(c_PI * p_num_1);
                p_TL_res1 = Math.Round(p_TL_res1, 3);
                res.Text = "Cos(" + p_num_1 + ") =" + p_TL_res1;
            }
            else if (p_num2_number == true && p_num1_number == false)
            {
                p_TL_res2 = Math.Sin(c_PI * p_num_2);
                p_TL_res2 = Math.Round(p_TL_res2, 3);
                res.Text = "Cos(" + p_num_2 + ") =" + p_TL_res2;
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }



        void f_tan(object sender, RoutedEventArgs e)
        {
            p_num1_number = this.IsNum1Number();
            p_num2_number = this.IsNum2Number();
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                p_FT1 = this.ForbidenTan(p_num_1);
                p_FT2 = this.ForbidenTan(p_num_2);
                if (p_FT1 == false && p_FT2 == false)
                {
                    p_TL_res1 = (Math.Sin(c_PI * p_num_1) / Math.Cos(c_PI * p_num_1));
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    p_TL_res2 = (Math.Sin(c_PI * p_num_2) / Math.Cos(c_PI * p_num_2));
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Tan(" + p_num_1 + ") =" + p_TL_res1 + "\n Tan(" + p_num_2 + ")=" + p_TL_res2;
                }
                else
                {
                    res.Text = "Math Error";
                }

            }
            else if (p_num1_number == true && p_num2_number == false)
            {
                p_FT1 = this.ForbidenTan(p_num_1);
                if (p_FT1 == false)
                {
                    p_TL_res1 = (Math.Sin(c_PI * p_num_1) / Math.Cos(c_PI * p_num_1));
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    res.Text = "Tan(" + p_num_1 + ") =" + p_TL_res1;
                }
                else
                {
                    res.Text = "Math Error";
                }


            }
            else if (p_num2_number == true && p_num1_number == false)
            {
                p_FT2 = this.ForbidenTan(p_num_1);
                if (p_FT2 == false)
                {
                    p_TL_res2 = (Math.Sin(c_PI * p_num_2) / Math.Cos(c_PI * p_num_2));
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Tan(" + p_num_2 + ") =" + p_TL_res2;
                }
                else
                {
                    res.Text = "Math Error";
                }
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }



        //Log And Ln
        void f_ln(object sender, RoutedEventArgs e)
        {
            p_num1_number = this.IsNum1Number();
            p_num2_number = this.IsNum2Number();
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                if (p_num_1 < 0 || p_num_2 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res1 = Math.Log(p_num_1);
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    p_TL_res2 = Math.Log(p_num_2);
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Ln(" + p_num_1 + ") =" + p_TL_res1 + "\n Ln(" + p_num_2 + ")=" + p_TL_res2;
                }
            }
            else if (p_num1_number == true && p_num2_number == false)
            {
                if (p_num_1 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res1 = Math.Log(p_num_1);
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    res.Text = "Ln(" + p_num_1 + ") =" + p_TL_res1;
                }

            }
            else if (p_num2_number == true && p_num1_number == false)
            {
                if (p_num_2 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res2 = Math.Log(p_num_2);
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Ln(" + p_num_2 + ") =" + p_TL_res2;
                }
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }



        void f_log(object sender, RoutedEventArgs e)
        {
            p_num1_number = this.IsNum1Number();
            p_num2_number = this.IsNum2Number();
            p_AllNumbers = this.IsNumber();
            if (p_AllNumbers == true)
            {
                if (p_num_1 < 0 || p_num_2 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res1 = Math.Log(p_num_1, 10);
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    p_TL_res2 = Math.Log(p_num_2, 10);
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Log(" + p_num_1 + ") =" + p_TL_res1 + "\n Log(" + p_num_2 + ")=" + p_TL_res2;
                }
            }
            else if (p_num1_number == true && p_num2_number == false)
            {
                if (p_num_1 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res1 = Math.Log(p_num_1, 10);
                    p_TL_res1 = Math.Round(p_TL_res1, 3);
                    res.Text = "Log(" + p_num_1 + ") =" + p_TL_res1;
                }

            }
            else if (p_num2_number == true && p_num1_number == false)
            {
                if (p_num_2 < 0)
                {
                    res.Text = "Math Error";
                }
                else
                {
                    p_TL_res2 = Math.Log(p_num_2, 10);
                    p_TL_res2 = Math.Round(p_TL_res2, 3);
                    res.Text = "Log(" + p_num_2 + ") =" + p_TL_res2;
                }
            }
            else
            {
                res.Text = "Syntax Error";
            }
        }


    }
}
