using System;
using System.Windows;
using System.Windows.Interop;

namespace p_hello_cad
{
    /// <summary>
    /// شبه منحرف متساو الساقين
    /// مشتق من شبه المنحرف
    /// مشتق من الشكل الرباعي العام
    /// </summary>
    class _c_tr_isosceles : _c_qd_trapezoid
    {
        public override string[] f_lables_()
        {
            return new string[] { "نقطة 1", "نقطة 2", "نقطة 3" };
        }

        public override void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {
            // المتجهين
            // AB, AC
            Point l_bvr_ = new Point(
                p_pts_[0].X - p_pts_[1].X,
                p_pts_[0].Y - p_pts_[1].Y);   // vector AB

            Point l_cvr_ = new Point(
                p_pts_[2].X - p_pts_[1].X,
                p_pts_[2].Y - p_pts_[1].Y);   // vector AC

            double l_abl_ = Math.Sqrt(Math.Pow(l_bvr_.X, 2) + Math.Pow(l_bvr_.Y, 2));   // AB length

            double l_prj_ = ((l_bvr_.X * l_cvr_.X) + (l_bvr_.Y * l_cvr_.Y)) / l_abl_;   // projection of AC on AB
            double l_cdl_ = l_abl_ - (2 * l_prj_);

            base.v_caluclate_(new Point[] { p_pts_[0], p_pts_[1], p_pts_[2] }, new double[] { l_cdl_ });
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