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


        }

        double p_num_1;
        double p_num_2;
        double p_res;
        bool p_num1_number;
        bool p_num2_number;
        bool p_AllNumbers;


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
                    p_res = p_num_1 / p_num_2;
                    res.Text = p_res.ToString();
                }
            }
            else
            {
                res.Text = "Syntax Error";
            }



        }
        void f_clr(object sender, RoutedEventArgs e)
        {
            num_1.Text = "";
            num_2.Text = "";
        }
    }
}
