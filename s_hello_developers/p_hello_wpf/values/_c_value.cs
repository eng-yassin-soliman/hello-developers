using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace p_hello_wpf.values
{
    /// <summary>
    /// الكلاس الأساسية اللي بيتفرع منها العدد والمتجه
    /// </summary>
    public class _c_value
    {
        public List<double> s_num_ = new List<double>();
        public List<TextBox> s_txb_ = new List<TextBox>();
        public Boolean s_rdo_ = false; // هل يمكن التعديل على الرقم؟

        public static TextBox s_foc_; // مربع النص الذي يتم الكتابة فيه

        /// <summary>
        /// الكود اللي بيشتغل عند انشاء نسخة جديدة من الكلاس
        /// </summary>
        /// <param name="p_siz_">عدد عناصر العدد المركب أول المتجه</param>
        /// <param name="p_rdo_">للقراءة فقط؟</param>
        public _c_value(int p_siz_, Boolean p_rdo_, Panel p_pnl_)
        {
            p_pnl_.Children.Clear();
            s_rdo_ = p_rdo_;

            for (int i_ndx_ = 0; i_ndx_ < p_siz_; i_ndx_++)
            {
                s_num_.Add(0);

                TextBox l_txb_ = new TextBox
                {
                    Margin = new Thickness(5),
                    Padding = new Thickness(5),
                    Background = Brushes.Transparent,
                    IsEnabled = !p_rdo_
                };
                s_txb_.Add(l_txb_);
                p_pnl_.Children.Add(l_txb_);

                if (!p_rdo_) { l_txb_.Text = "0"; }

                l_txb_.PreviewTextInput += v_update_;
                l_txb_.TextChanged += v_changed_;
                l_txb_.GotFocus += v_got_focus_;
            }
        }

        // هل المدخلات تساوي رقم عشري صالح؟
        public static Boolean f_valid_(TextBox p_txb_,string p_txt_)
        {
            try
            {
                double.Parse(p_txt_);
                return true;
            }
            catch (Exception p_exp_)
            {
                return false;
            }
        }

        // يرفض مدخلات يدوية غير صالحة
        void v_update_(object p_snd_, TextCompositionEventArgs p_arg_)
        {
            TextBox l_txb_ = (TextBox)p_snd_;
            string l_new_ = l_txb_.Text.Insert(l_txb_.SelectionStart, p_arg_.Text);

            if (l_new_ == "-")
            {
                p_arg_.Handled = false;
                return;
            }

            p_arg_.Handled = !_c_value.f_valid_(l_txb_, l_new_);
        }

        void v_changed_(object p_snd_, EventArgs p_arg_)
        {
            TextBox l_txb_ = (TextBox)p_snd_;
            int l_ndx_ = s_txb_.IndexOf(l_txb_);
            if (_c_value.f_valid_(l_txb_, l_txb_.Text))
            {
                s_num_[l_ndx_] = double.Parse(l_txb_.Text);
                l_txb_.Background = Brushes.Transparent;
            }
            else
            {
                s_num_[l_ndx_] = double.NaN;
                l_txb_.Background = Brushes.MistyRose;
            }
        }

        // لما يكون مربع نص واخد المؤشر وجاهز للكتابة
        public void v_got_focus_(object p_snd_, EventArgs p_arg_)
        {
            _c_value.s_foc_ = (TextBox)p_snd_;
        }

        public void v_set_val_(int p_ndx_, double p_val_)
        {
            s_num_[p_ndx_] = p_val_;
            s_txb_[p_ndx_].Text = p_val_.ToString();
        }

        public void v_enable_()
        {
            foreach (TextBox i_txb_ in s_txb_)
            {
                i_txb_.IsEnabled = true;
                i_txb_.Text = "0";
            }
        }

        // العمليات الحسابية كلها هاتتم هنا
        
        /// <summary>
        /// القيمة المطلقة لعدد أو متجه
        /// </summary>
        /// <param name="p_nm1_">العدد أو المتجه المطلوب إيجاد القيمة المطلقة له</param>
        public void v_abs_(_c_value p_nm1_)
        {
            double l_ans_ = 0;
            for (int i_ndx_ = 0; i_ndx_ < s_num_.Count; i_ndx_++)
            {
                l_ans_ += Math.Pow(p_nm1_.s_num_[i_ndx_], 2);
            }

            v_set_val_(0, Math.Sqrt(l_ans_));
        }

        /// <summary>
        /// ضرب عددين او متجهين ضرب قياسي
        /// </summary>
        /// <param name="p_nm1_">العدد أو المتجه الأول</param>
        /// <param name="p_nm2_">العدد أو المتجه الثاني</param>
        public virtual void v_product_(_c_value p_nm1_, _c_value p_nm2_)
        {
            // الميثود دي معمولها اوفررايد
            // لان كل كلاس بتورث من الكلاس دي
            // ليها طريقة مختلفة في حساب عملية الضرب
        }

        /// <summary>
        /// الجمع
        /// </summary>
        /// <param name="p_nm1_">العدد أو المتجه الأول</param>
        /// <param name="p_nm2_">العدد أو المتجه الثاني</param>
        public void v_sum_(_c_value p_nm1_, _c_value p_nm2_)
        {
            for (int i_ndx_ = 0; i_ndx_ < s_num_.Count; i_ndx_++)
            {
                try
                {
                    double l_num_ = p_nm1_.s_num_[i_ndx_] + p_nm2_.s_num_[i_ndx_];
                    v_set_val_(i_ndx_, l_num_);
                }
                catch (Exception p_exp_)
                {
                    v_set_val_(i_ndx_, double.NaN);
                }
            }
        }
    }
}