using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace p_hello_wpf.values
{
    /// <summary>
    /// متجه
    /// </summary>
    class _c_vector : _c_value
    {
        public _c_vector(int p_siz_, Boolean p_rdo_, Panel p_pnl_) : base
            (p_siz_, p_rdo_, p_pnl_) { }

        int f_age_()
        {
            return 34;
        }

        DateTime f_now_()
        {
            return DateTime.Now;
        }

        public override void v_product_(_c_value p_nm1_, _c_value p_nm2_)
        {
            base.v_product_(p_nm1_, p_nm2_);

            double l_ans_ = 0;
            for (int i_ndx_ = 0; i_ndx_ < s_num_.Count; i_ndx_++)
            {
                l_ans_ += p_nm1_.s_num_[i_ndx_] * p_nm2_.s_num_[i_ndx_];
            }

            v_set_val_(0, l_ans_);
        }

        public override void v_factorial_(_c_value p_nm1_)
        {
            // ماينفعش اخذ مضروب لمتجه
            for (int i_ndx_ = 0; i_ndx_ < s_num_.Count; i_ndx_++)
            {
                v_set_val_(i_ndx_, double.NaN);
            }
        }
    }
}