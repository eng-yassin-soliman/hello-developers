using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace p_ArabiCAD
{
    /// <summary>New document, open and save...</summary>
    public partial class _w_main
    {
        public string s_loc_ = "";

        public _w_main(string p_loc_)
        {
            InitializeComponent();

            if (p_loc_ == "") { return; }

            // ناقص هنا ازبط الاعدادات لو الملف فيه مسارات يكون الحالة بتاعته ايه
            s_loc_ = p_loc_;
            List<Path> l_lst_ = new List<Path>();
            try
            {
                l_lst_ = (List<Path>)System.Xaml.XamlServices.Load(s_loc_);                
            }
            catch
            {
                MessageBox.Show("الملف غير صالح");
                Close();
                return;
            }

            s_loc_ = p_loc_;
            l_lst_ = (List<Path>)System.Xaml.XamlServices.Load(s_loc_);
            Title = "ArabiCAD - " + s_loc_;
            foreach (Path i_pth_ in l_lst_) { b_cnv_.Children.Add(i_pth_); }
        }

        /// <summary>Menu</summary>
        public void v_new_(object p_snd_, RoutedEventArgs p_arg_)
        {
            _c_app.v_new_("");
        }

        public void v_open_(object p_snd_, RoutedEventArgs p_arg_)
        {
            OpenFileDialog l_dia_ = new OpenFileDialog();
            if (!(bool)l_dia_.ShowDialog()) { return; }

            _c_app.v_new_(l_dia_.FileName);
        }

        public void v_save_(object p_snd_, RoutedEventArgs p_arg_) 
        {
            SaveFileDialog l_dia_ = new SaveFileDialog();
            if (s_loc_ == "")
            {
                l_dia_.AddExtension = true;
                l_dia_.OverwritePrompt = true;
                l_dia_.DefaultExt = "acd";
                l_dia_.AddExtension = true;
                l_dia_.Filter = "ArabiCAD drawing (*.acd)|*.acd";
                
                if (!(bool)l_dia_.ShowDialog()) { return; }
            }

            List<Path> l_lst_ = new List<Path>();
            foreach (Path i_pth_ in b_cnv_.Children) { l_lst_.Add(i_pth_); }

            try
            {
                System.Xaml.XamlServices.Save(l_dia_.FileName, l_lst_);
            }
            catch
            {
                MessageBox.Show("لايمن الكتابة على الملف، قد يكون الملف قد الاستخدام");
                return;
            }

            s_loc_ = l_dia_.FileName;
            Title = "ArabiCAD - " + s_loc_;
        }
    }
}