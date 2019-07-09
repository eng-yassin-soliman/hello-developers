using System;
using System.Windows;

namespace p_hello_cad
{
    /// <summary>
    /// متواز أضلاع
    /// مشتق من شبه المنحرف
    /// مشتق من الشكل ارباعي العام
    /// </summary>
    class _c_tr_parallelogram : _c_qd_trapezoid
    {
        public override string[] f_lables_()
        {
            return new string[] { "نقطة 1", "نقطة 2", "نقطة 3" };
        }

        public override void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {
            // ايجاد زاوية ميل القاعدة
            double l_adj_ = (p_pts_[1].X - p_pts_[0].X);                            // المقابل
            double l_ops_ = (p_pts_[1].Y - p_pts_[0].Y);                            // المجاور
            double l_hyp_ = Math.Sqrt(Math.Pow(l_adj_, 2) + Math.Pow(l_ops_, 2));   // الوتر
            double l_cos_ = l_adj_ / l_hyp_;
            double l_sin_ = l_ops_ / l_hyp_;

            base.v_caluclate_(new Point[] { p_pts_[0], p_pts_[1], p_pts_[2] }, new double[] { l_hyp_ });
        }

        public override void v_load_text_(string[] p_pts_)
        {
            Point[] l_pts_ = new Point[3];

            // إضافة أول 3 نقط من المصفوفة
            for (int i_ndx_ = 0; i_ndx_ < 3; i_ndx_++)
            {
                l_pts_[i_ndx_] = f_parse_point_(p_pts_[i_ndx_]);
            }

            v_caluclate_(l_pts_, null);
        }
    }
}