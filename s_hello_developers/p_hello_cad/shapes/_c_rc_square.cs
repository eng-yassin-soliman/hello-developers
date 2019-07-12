using System;
using System.Windows;

namespace p_hello_cad
{
    /// <summary>
    /// مربع
    /// مشتق من مستطيل
    /// مشتق من متوازي مستطيلات
    /// مشتق من شبه المنحرف
    /// مشتق من شكل رباعي عام
    /// </summary>
    class _c_rc_square : _c_pr_rectangle
    {
        public override string[] f_lables_()
        {
            return new string[] { "نقطة 1", "نقطة 2"};
        }

        public override void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {

            MessageBox.Show("0");


            // ايجاد زاوية ميل القاعدة
            double l_adj_ = (p_pts_[1].X - p_pts_[0].X);                            // المقابل 

            MessageBox.Show("l_adj_" + l_adj_.ToString());

            double l_ops_ = (p_pts_[1].Y - p_pts_[0].Y);                            // المجاور
            double l_hyp_ = Math.Sqrt(Math.Pow(l_adj_, 2) + Math.Pow(l_ops_, 2));   // الوتر

            // Third point
            Point l_pnt_ = new Point();
            l_pnt_.X = p_pts_[1].X + l_ops_;
            l_pnt_.Y = p_pts_[1].Y - l_adj_;

            base.v_caluclate_(new Point[] { p_pts_[0], p_pts_[1] }, new double[] { l_hyp_ });
        }

        public override void v_load_text_(string[] p_pts_)
        {
            Point[] l_pts_ = new Point[2];

            // إضافة أول 3 نقط من المصفوفة
            for (int i_ndx_ = 0; i_ndx_ < 2; i_ndx_++)
            {
                l_pts_[i_ndx_] = f_parse_point_(p_pts_[i_ndx_]);
            }

            v_caluclate_(l_pts_, null);
        }
    }
}