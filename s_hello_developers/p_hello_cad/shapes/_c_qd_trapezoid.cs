using System;
using System.Windows;

namespace p_hello_cad
{
    /// <summary>
    /// شبه منحرف
    /// وارث من الشكل الرباعي العام
    /// </summary>
    class _c_qd_trapezoid : _c_quadrilateral
    {
        public override string[] f_lables_()
        {
            return new string[] { "نقطة 1 (القاعدة)", "نقطة 2 (القاعدة)", "نقطة 3", "طول الضلع الموازي " };
        }

        public override void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {
            // ايجاد زاوية ميل القاعدة
            double l_adj_ = (p_pts_[1].X - p_pts_[0].X);                            // المقابل
            double l_ops_ = (p_pts_[1].Y - p_pts_[0].Y);                            // المجاور
            double l_hyp_ = Math.Sqrt(Math.Pow(l_adj_, 2) + Math.Pow(l_ops_, 2));   // الوتر
            double l_cos_ = l_adj_ / l_hyp_;
            double l_sin_ = l_ops_ / l_hyp_;

            // رابع نقطة
            Point l_4th_ = new Point();
            l_4th_.X = p_pts_[2].X - (p_val_[0] * l_cos_);
            l_4th_.Y = p_pts_[2].Y - (p_val_[0] * l_sin_);

            base.v_caluclate_(new Point[] { p_pts_[0], p_pts_[1], p_pts_[2], l_4th_ }, null);
        }

        public override void v_load_text_(string[] p_pts_)
        {
            Point[] l_pts_ = new Point[3];

            // إضافة أول 3 نقط من المصفوفة
            for (int i_ndx_ = 0; i_ndx_ < 3; i_ndx_++)
            {
                l_pts_[i_ndx_] = f_parse_point_(p_pts_[i_ndx_]);
            }

            // طول الضلع الموازي
            double l_lng_ = f_parse_number_(p_pts_[3]);

            v_caluclate_(l_pts_, new double[] { l_lng_ });
        }
    }
}