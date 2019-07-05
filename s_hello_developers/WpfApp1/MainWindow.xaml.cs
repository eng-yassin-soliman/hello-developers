using System.Windows;
using static System.Math;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double p_num_1 = 0;
        double p_num_2 = 0;
        double p_result_ = 0;
        string opp = "";


        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void N_1_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 1 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 1 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 1 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {
                p_num_1 = 1 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_2_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 2 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 2 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 2 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {

                p_num_1 = 2 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_3_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 3 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 3 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 3 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {

                p_num_1 = 3 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_4_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 4 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 4 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 4 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {

                p_num_1 = 4 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_5_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 5 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 5 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 5 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {

                p_num_1 = 5 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_6_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 6 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 6 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 6 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {

                p_num_1 = 6 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_7_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 7 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 7 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 7 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {
                p_num_1 = 7 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_8_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 8 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 8 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 8 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }

            }
            else
            {
                p_num_1 = 8 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }
        private void N_9_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = 9 + (p_num_2 * 10);
                    t_1.Text =  opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = 9 + (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = 9 + (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {
                p_num_1 = 9 + (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }

        private void N_0_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp != "")
            {
                if (opp == "Sin(")
                {
                    p_num_2 = (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                if (opp == "Ln(")
                {
                    p_num_2 = (p_num_2 * 10);
                    t_1.Text = opp + p_num_2;
                }
                else
                {
                    p_num_2 = (p_num_2 * 10);
                    t_1.Text = p_num_1 + opp + p_num_2;
                }
            }
            else
            {
                p_num_1 = (p_num_1 * 10);
                t_1.Text = p_num_1.ToString();
            }
        }

        private void B_add_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "+";
            t_1.Text = p_num_1 + opp;
        }

        private void B_sub_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "-";
            t_1.Text = p_num_1 + opp;

        }

        private void B_mul_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "x";
            t_1.Text = p_num_1 + opp;

        }

        private void B_div_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "÷";
            t_1.Text = p_num_1 + opp;

        }
        private void B_Sin_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "Sin(";
            
            t_1.Text = opp;
        }
        private void B_Ln_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            opp = "Ln(";
            t_1.Text = opp;
        }
        private void B_equ_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp == "+")
            {
                p_result_ = p_num_1 + p_num_2;
                t_1.Text = p_result_.ToString();
            }
            if (opp == "-")
            {
                p_result_ = p_num_1 - p_num_2;
                t_1.Text = p_result_.ToString();
            }
            if (opp == "x")
            {
                p_result_ = p_num_1 * p_num_2;
                t_1.Text = p_result_.ToString();
            }
            if (opp == "÷")
            {
                if (p_num_2 == 0)
                {
                    t_1.Text = "ERROR";
                }
                else
                {
                    p_result_ = p_num_1 / p_num_2;
                    t_1.Text = p_result_.ToString();
                }
            }
            if (opp == "Sin(")
            {
                p_result_ = Sin((p_num_2 / 180) * PI);
                t_1.Text = p_result_.ToString();
            }
            if (opp == "Ln(")
            {
                p_result_ = Log(p_num_2);
                if (p_num_2 > 0)
                {
                    t_1.Text = p_result_.ToString();
                }
                else
                {
                    t_1.Text = "ERROR";
                }

            }
        }

        private void B_del_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (opp == "")
            {
                p_num_1 = 0;
                t_1.Text = p_num_1.ToString();
            }
            else
            {
                p_num_2 = 0;
                t_1.Text = p_num_1 + opp;
            }
        }

        private void Clr_Click(object p_snd_, RoutedEventArgs p_arg_)
        {
            p_num_1 = 0;
            p_num_2 = 0;
            p_result_ = 0;
            opp = "";
            t_1.Text = "";
        }
    }
}
