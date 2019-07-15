using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace p_hello_wpf.values
{
    /// <summary>
    /// عدد حقيقي أو مركب
    /// </summary>
    class _c_number : _c_value
    {
        public _c_number(int p_siz_, Boolean p_rdo_, Panel p_pnl_) : base(p_siz_, p_rdo_, p_pnl_) { }

        public override void v_product_(_c_value p_nm1_, _c_value p_nm2_)
        {
            base.v_product_(p_nm1_, p_nm2_);

            double[] l_ans_ = { 0, 0 };

            if (s_num_.Count == 1)  // Real
            {
                l_ans_[0] = p_nm1_.s_num_[0] * p_nm2_.s_num_[0];
                v_set_val_(0, l_ans_[0]);
            }
            else                    // Imaginary
            {
                // Real part
                l_ans_[0] = (p_nm1_.s_num_[0] * p_nm2_.s_num_[0]) - (p_nm1_.s_num_[1] * p_nm2_.s_num_[1]);
                v_set_val_(0, l_ans_[0]);
                // Imaginary part
                l_ans_[1] = (p_nm1_.s_num_[0] * p_nm2_.s_num_[1]) + (p_nm1_.s_num_[1] * p_nm2_.s_num_[0]);
                v_set_val_(1, l_ans_[1]);
            }
        }

        public override void v_factorial_(_c_value p_nm1_)
        {
            double l_num_ = p_nm1_.s_num_[0];

            if (p_nm1_.s_num_.Count != 1 ||     // لو عدد مركب مينفعش
                l_num_ < 0 ||                   // لو عدد سالب ماينفعش
                Math.Floor(l_num_) != l_num_)   // لو عدد غير صحيح مينفعش
            {
                for (int i_ndx_ = 0; i_ndx_ < s_num_.Count; i_ndx_++)
                {
                    v_set_val_(i_ndx_, double.NaN);
                }
                return;
            }

            double l_res_ = 1;
            while (true)
            {
                if (l_num_ == 0) { break; }

                l_res_ *= l_num_;
                l_num_ -= 1;
            }

            v_set_val_(0, l_res_);
        }
    }
}