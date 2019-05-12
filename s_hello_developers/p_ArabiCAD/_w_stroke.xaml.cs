using System.Windows;

namespace p_ArabiCAD
{
    /// <summary>
    /// Interaction logic for _w_stroke.xaml
    /// </summary>
    public partial class _w_stroke : Window
    {
        public _w_stroke()
        {
            InitializeComponent();
        }

        void v_app_(object p_snd_, RoutedEventArgs p_arg_)
        {
            if (!b_thk_.s_vld_)
            {
                MessageBox.Show("القيمة التي أدخلتها غير صالحة");
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}