using System;
using System.Windows;

namespace p_hello_cad
{
    /// <summary>
    /// مستطيل
    /// مشتق من متواز الأضلاع
    /// مشتق من شبه المنحرف
    /// مشتق من الشكل الرباعي العام
    /// </summary>
    class _c_pr_rectangle : _c_tr_parallelogram
    {
        public override string[] f_lables_()
        {
            return new string[] { "نقطة 1", "نقطة 2", "طول أي ضلع" };
        }

        public override void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {
            // ايجاد زاوية ميل القاعدة
            double l_adj_ = (p_pts_[1].X - p_pts_[0].X);                            // المقابل
            double l_ops_ = (p_pts_[1].Y - p_pts_[0].Y);                            // المجاور
            double l_hyp_ = Math.Sqrt(Math.Pow(l_adj_, 2) + Math.Pow(l_ops_, 2));   // الوتر
            double l_cos_ = l_adj_ / l_hyp_;
            double l_sin_ = l_ops_ / l_hyp_;

            // Second side length
            double l_2nd_ = p_val_[0];

            // Third point
            Point l_pnt_ = new Point();
            l_pnt_.X = p_pts_[1].X + (l_2nd_ * l_sin_);     // الساين والكوزان معكوسين عشان 90 درجة
            l_pnt_.Y = p_pts_[1].Y - (l_2nd_ * l_cos_);

            base.v_caluclate_(new Point[] { p_pts_[0], p_pts_[1], l_pnt_ }, null);
        }

        public override void v_load_text_(string[] p_pts_)
        {
            Point[] l_pts_ = new Point[2];

            // إضافة أول 3 نقط من المصفوفة
            for (int i_ndx_ = 0; i_ndx_ < 2; i_ndx_++)
            {
                l_pts_[i_ndx_] = f_parse_point_(p_pts_[i_ndx_]);
            }

            v_caluclate_(l_pts_, new double[] { f_parse_number_(p_pts_[2]) });
        }
    }
}