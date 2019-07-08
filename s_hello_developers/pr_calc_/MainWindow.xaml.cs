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

namespace Wpfcalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///         
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            b_sum.Click += new RoutedEventHandler(v_sum);
            b_sub.Click += new RoutedEventHandler(v_subtract);
            b_mul.Click += new RoutedEventHandler(v_multiply);
            b_div.Click += new RoutedEventHandler(v_divide);
            b_sin.Click += new RoutedEventHandler(v_sine);
            b_lne.Click += new RoutedEventHandler(v_ln);
        }
        void v_sum(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);
                double l_n2 = double.Parse(box2.Text);
                string l_str = (l_n1 + l_n2).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }
        }
        void v_subtract(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);
                double l_n2 = double.Parse(box2.Text);
                string l_str = (l_n1 - l_n2).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }

        void v_multiply(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);
                double l_n2 = double.Parse(box2.Text);
                string l_str = (l_n1 * l_n2).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }

        void v_divide(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);
                double l_n2 = double.Parse(box2.Text);
                string l_str = (l_n1 / l_n2).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }


        void v_sine(object p_snd_, RoutedEventArgs p_arg_)
        {

            try
            {
                double l_n1 = double.Parse(box1.Text);

                string l_str = (Math.Sin(l_n1)).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }

        void v_ln(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);

                string l_str = (Math.Log(l_n1)).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }

        void v_factorial(object p_snd_, RoutedEventArgs p_arg_)
        {
            try
            {
                double l_n1 = double.Parse(box1.Text);



                string l_str = ((l_n1)).ToString();

                MessageBox.Show((l_str));
            }
            catch (Exception p_exp_)
            {
                MessageBox.Show(p_exp_.Message);
            }

        }

        // private void Button_Click(object sender, RoutedEventArgs e)
        // {

        //}
        //void f_subtract(int first, int second)
        //{
        //    MessageBox.Show(" (first - second).ToString()");
        //}
        //void f_multiply(int first, int second)
        //{
        //    MessageBox.Show ("(first * second).ToString()")
        //}
        //void f_divide(int first, int second)
        //{
        //    return first / second;
        //}
    }
}
