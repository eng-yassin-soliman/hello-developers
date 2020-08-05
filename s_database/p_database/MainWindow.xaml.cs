using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace p_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool s_ext_ = true;

        List<_c_person> s_per_;
        _c_db s_dal_ = new _c_db();

        public MainWindow()
        {
            InitializeComponent();

            v_read_(0, 100);
        }

        void v_read_(int p_skp_, int p_cnt_) 
        {
            // Query:
            s_dal_.f_open_();

            var l_qry_ = (from i_per_ in s_dal_.t_persons
                          where i_per_.s_nam_ == "Yassin"
                          orderby i_per_.s_dat_ descending
                          select i_per_).Skip(p_skp_).Take(p_cnt_);

            // Query has not been sent to db server
            s_per_ = l_qry_.ToList<_c_person>();
            // Query has been sent!
            
            s_dal_.f_close_();

            // UI: Show records
            foreach (_c_person i_per_ in s_per_)
            {
                string l_str_ =
                    i_per_.s_uid_ + " - " +
                    i_per_.s_dat_.Hour.ToString("00") + " - " +
                    i_per_.s_dat_.Minute.ToString("00") + " - " +
                    i_per_.s_dat_.Second.ToString("00") + " - " +
                    i_per_.s_nam_;

                b_lst_.Items.Add(l_str_);
            };
        }

        private void v_add_(object p_snd_, RoutedEventArgs p_arg_)
        {
            s_dal_.f_open_();

            var l_per_ = new _c_person() { s_dat_ = DateTime.Now, s_nam_ = "yassin", s_gnd_ = true };
            s_dal_.Entry(l_per_).State = EntityState.Added;

            s_dal_.SaveChanges();
            s_dal_.f_close_();

            MessageBox.Show("Record Added!");
            s_ext_ = false;
            Close();
        }

        private void v_update_(object sender, RoutedEventArgs e)
        {
            int l_ndx_ = b_lst_.SelectedIndex;
            if (l_ndx_ == -1)
            {
                MessageBox.Show("Please select a record!");
                return;
            }

            var l_per_ = s_per_[l_ndx_];
            l_per_.s_nam_= "Name_" + DateTime.Now.Ticks;

            s_dal_.f_open_();
            s_dal_.Entry(l_per_).State = EntityState.Modified;

            s_dal_.SaveChanges();
            s_dal_.f_close_();

            MessageBox.Show("Record Modified!");
            s_ext_ = false;
            Close();
        }

        private void v_delete_(object sender, RoutedEventArgs e)
        {
            int l_ndx_ = b_lst_.SelectedIndex;
            if (l_ndx_ == -1)
            {
                MessageBox.Show("Please select a record!");
                return;
            }

            var l_per_ = s_per_[l_ndx_];

            s_dal_.f_open_();
            s_dal_.Entry(l_per_).State = EntityState.Deleted;

            s_dal_.SaveChanges();
            s_dal_.f_close_();

            MessageBox.Show("Record Deleted!");
            s_ext_ = false;
            Close();
        }
    }
}