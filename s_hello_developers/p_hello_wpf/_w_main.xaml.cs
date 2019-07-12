using p_hello_wpf.values;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace p_hello_wpf
{
    public partial class _w_main : Window
    {
        public _c_value s_nm1_;
        public _c_value s_nm2_;
        public _c_value s_ans_;

        // Operations
        public string[] s_ops_ = {
            "sin", "cos", "x^2", "sqrt", "ln", "abs", "!",  // One input operations
            "*", "/", "-", "+", "=" };

        // Two input opertion pressed button
        public string s_opr_ = string.Empty;

        // Status: Ready=0, Second input=1, Answered=2
        public int s_stt_ = 0;

        /// <summary>
        /// Default constructor
        /// هنا الكود اللي بيشتغل عند انشاء
        /// new _w_main
        /// </summary>
        public _w_main()
        {
            InitializeComponent();

            // إضافة زراير الأرقام
            string[] l_num_ = { "7", "8", "9", "4", "5", "6", "1", "2", "3", "0", "." };
            foreach (string i_num_ in l_num_)
            {
                Button l_btn_ = new Button
                {
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5),
                    Content = i_num_,
                };
                l_btn_.Click += v_numbers_;

                b_pnl_.Children.Add(l_btn_);
            }

            Button l_clr_ = new Button
            {
                Width = 50,
                Height = 50,
                Margin = new Thickness(5),
                Content = "Clr",
                Background = Brushes.MistyRose
            };
            l_clr_.Click += v_clear_;

            b_pnl_.Children.Add(l_clr_);

            foreach (string i_num_ in s_ops_)
            {
                Button l_btn_ = new Button
                {
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(5),
                    Content = i_num_,
                };
                l_btn_.Click += v_operators_;

                b_opr_.Children.Add(l_btn_);
            }
        }

        /// <summary>
        /// الكود اللي بيشتغل لما الويندو تكون حملت وجاهزة
        /// </summary>
        /// <param name="p_arg_">لازم تكون موجودة  وخلاص</param>
        protected override void OnContentRendered(EventArgs p_arg_)
        {
            base.OnContentRendered(p_arg_);
            // اضافة مربعات النص وكدة
            b_num_.Checked += v_mode_changed_;
            b_num_.Unchecked += v_mode_changed_;

            b_siz_.SelectionChanged += v_size_changed_;
            b_num_.IsChecked = true;
        }

        /// <summary>
        /// الكود اللي بيشتغل لما حد يدوس زرار رقم
        /// </summary>
        /// <param name="p_snd_">الزرار اللي اتداس عليه</param>
        /// <param name="p_arg_">لازم تكون موجودة  وخلاص</param>
        void v_numbers_(object p_snd_, EventArgs p_arg_)
        {
            Button l_btn_ = (Button)p_snd_;
            string l_num_ = l_btn_.Content.ToString();

            TextBox l_txb_ = _c_value.s_foc_;
            if (l_txb_.Text == "0")
            {
                l_txb_.Text = l_num_;
                return;
            }

            string l_new = l_txb_.Text + l_num_;
            if (_c_value.f_valid_(l_txb_, l_new)) { l_txb_.Text = l_new; }
        }

        /// <summary>
        /// الكود اللي بيشتغل لما حد يدوس عملية حسابية
        /// </summary>
        /// <param name="p_snd_">الزرار اللي اتداس عليه</param>
        /// <param name="p_arg_">لازم تكون موجودة  وخلاص</param>
        void v_operators_(object p_snd_, EventArgs p_arg_)
        {
            Button l_btn_ = (Button)p_snd_;
            string l_opr_ = (string)l_btn_.Content;

            switch (s_stt_)
            {
                case 0:     // Ready
                    v_ready_(l_opr_);
                    break;

                case 1:     // Two input operation
                    v_equal_(l_opr_);
                    break;

                case 2:
                    break;  // Two input operation

            }
        }

        void v_ready_(string p_opr_)
        {
            // Tow input operation buttons
            string[] l_tio_ = s_ops_.Skip(7).Take(4).ToArray();
            if (l_tio_.Contains(p_opr_))
            {
                s_opr_ = p_opr_;    // Set the current operation
                s_stt_ = 1;         // Wait for second input

                int l_siz_ = b_siz_.SelectedIndex + 1 + ((Boolean)b_num_.IsChecked ? 0 : 1);
                if ((Boolean)b_num_.IsChecked)
                {
                    s_nm2_ = new _c_number(l_siz_, false, b_nm2_);
                }
                else
                {
                    s_nm2_ = new _c_vector(l_siz_, false, b_nm2_);
                }
                s_nm2_.s_txb_[0].Focus();
                return;
            }

            switch (p_opr_)
            {
                case "=":
                    return;

                case "sin":
                    break;

                case "cos":
                    break;

                case "x^2":
                    break;

                case "sqrt":
                    break;

                case "ln":
                    break;

                case "abs":
                    s_ans_.v_abs_(s_nm1_);
                    break;

                case "!":
                    break;
            }

            s_stt_ = 2;             // Answered
        }

        void v_equal_(string p_opr_)
        {
            if (p_opr_ != "=") { return; };

            switch (s_opr_)
            {
                case "+":
                    s_ans_.v_sum_(s_nm1_, s_nm2_);
                    break;

                case "-":
                    break;

                case "*":
                    s_ans_.v_product_(s_nm1_, s_nm2_);
                    break;

                case "/":
                    break;
            }

            s_stt_ = 2;
        }

        void v_mode_changed_(object p_snd_, EventArgs p_arg_)
        {
            b_siz_.Items.Clear();

            if ((Boolean)b_num_.IsChecked)
            {
                b_siz_.Items.Add("حقيقي");
                b_siz_.Items.Add("مركب");
            }
            else
            {
                b_siz_.Items.Add("ثنائي الأبعاد");
                b_siz_.Items.Add("ثلاثي الأبعاد");
            }

            b_siz_.SelectedIndex = 0;
        }

        void v_size_changed_(object p_snd_, EventArgs p_arg_)
        {
            if (b_siz_.Items.Count == 0) { return; }
            v_renew_();
        }

        void v_clear_(object p_snd_, EventArgs p_arg_) { v_renew_(); }

        void v_renew_()
        {
            // بص يا معلم
            // اللستة بتاعت العدد الحقيقي والمركب والمتجه الثنائي والثلاثي
            // الاندكس بيبتدي من الصفر
            // يعني لو اخترت اول اختيار هايبقى بصفر
            // هانزود واحد عشان يساوي عدد مكونات الفكتور او العدد المركب
            // بالنسبة للفكتور هانزود واحد كمان عشان هو
            // يا اما ثنائي يا اما ثلاثي
            int l_siz_ = b_siz_.SelectedIndex + 1 + ((Boolean)b_num_.IsChecked ? 0 : 1);

            if ((Boolean)b_num_.IsChecked)
            {
                s_nm1_ = new _c_number(l_siz_, false, b_nm1_);
                s_nm2_ = new _c_number(l_siz_, true, b_nm2_);
                s_ans_ = new _c_number(l_siz_, true, b_ans_);
            }
            else
            {
                s_nm1_ = new _c_vector(l_siz_, false, b_nm1_);
                s_nm2_ = new _c_vector(l_siz_, true, b_nm2_);
                s_ans_ = new _c_vector(l_siz_, true, b_ans_);
            }

            s_nm1_.s_txb_[0].Focus();
            s_stt_ = 0;
        }
    }
}