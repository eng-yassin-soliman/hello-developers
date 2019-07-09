using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace p_hello_cad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public _c_quadrilateral s_qdr_;

        public List<TextBox> s_txb_ = new List<TextBox>();

        public int s_act_ = 0;  // Active text box

        /// <summary>
        /// Default constuctor
        /// </summary>
        public MainWindow() { InitializeComponent(); }

        /// <summary>
        /// الكود اللي بيشتغل
        /// أول الويندو تخلص تحميل
        /// </summary>
        /// <param name="p_arg_">لازم يكون موجود</param>
        protected override void OnContentRendered(EventArgs p_arg_)
        {
            base.OnContentRendered(p_arg_); // لاوم تبقى موجودة وخلاص

            // باختار اول عنصر في القائمة لما البرنامج يحمل
            b_lst_.SelectedIndex = 0;
        }

        /// <summary>
        /// الكود اللي بيشتغل
        /// لما تختار عنصر من القائمة
        /// </summary>
        /// <param name="p_snd_">لازم يبقى موجود</param>
        /// <param name="p_arg_">لازم يبقى موجود</param>
        void v_selection_(object p_snd_, EventArgs p_arg_)
        {
            s_txb_.Clear();
            b_pnl_.Children.Clear();
            b_fig_.Segments.Clear();

            switch (b_lst_.SelectedIndex)
            {
                case 0:     // شكل رباعي عام
                    s_qdr_ = new _c_quadrilateral();
                    break;

                case 1:     // شبه منحرف
                    s_qdr_ = new _c_qd_trapezoid();
                    break;

                case 2:     // شبه منحرف متساو الساقين
                    s_qdr_ = new _c_tr_isosceles();
                    break;

                case 3:     // متواز الأضلاع
                    s_qdr_ = new _c_tr_parallelogram();
                    break;

                case 4:     // مستطيل
                    s_qdr_ = new _c_pr_rectangle();
                    break;

                case 5:     // مربع
                    s_qdr_ = new _c_rc_square();
                    break;

                case 6:     // كايت
                    s_qdr_ = new _c_qd_kite();
                    break;

                default:    // معين
                    s_qdr_ = new _c_kt_rhombus();
                    break;
            }

            string[] l_lbl_ = s_qdr_.f_lables_();
            foreach (string i_lbl_ in l_lbl_)
            {
                // عنوان كل مدخل من المدخلات
                TextBlock l_txt_ = new TextBlock
                {
                    Margin = new Thickness(5),
                    Padding = new Thickness(5),
                    Text = i_lbl_
                };

                TextBox l_txb_ = new TextBox
                {
                    Padding = new Thickness(5),
                    Margin = new Thickness(10, 0, 10, 5)
                };
                l_txb_.GotFocus += v_active_;   // لما تأكتف مربع النص يتعرف انهو مربع اللي هانكتب فيه

                b_pnl_.Children.Add(l_txt_);
                b_pnl_.Children.Add(l_txb_);

                s_txb_.Add(l_txb_);
            }
        }

        /// <summary>
        /// الكود اللي بيشتغل
        /// عند الضغط على زر ارسم
        /// </summary>
        /// <param name="p_snd_">لازم يبقى موجود</param>
        /// <param name="p_arg_">لازم يبقى موجود</param>
        void v_draw_(object p_snd_, EventArgs p_arg_)
        {
            b_fig_.Segments.Clear();

            List<string> l_str_ = new List<string>();
            foreach (TextBox i_txb_ in s_txb_)
            {
                l_str_.Add(i_txb_.Text);
            }

            s_qdr_.v_load_text_(l_str_.ToArray());
            if (!s_qdr_.s_vld_)
            {
                MessageBox.Show("خطأ في المدخلات");
                return;
            }

            b_fig_.StartPoint = s_qdr_.s_pts_[0];
            b_fig_.Segments.Add(new LineSegment(s_qdr_.s_pts_[1], true));
            b_fig_.Segments.Add(new LineSegment(s_qdr_.s_pts_[2], true));
            b_fig_.Segments.Add(new LineSegment(s_qdr_.s_pts_[3], true));
        }

        void v_active_(object p_snd_, EventArgs p_arg_)
        {
            TextBox l_txb_ = (TextBox)p_snd_;
            s_act_ = s_txb_.IndexOf(l_txb_);
        }

        void v_pick_point_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            s_txb_[s_act_].Text = p_arg_.GetPosition((Canvas)p_snd_).ToString();
        }
    }
}