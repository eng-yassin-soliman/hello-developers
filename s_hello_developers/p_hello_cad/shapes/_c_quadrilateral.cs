using System;
using System.Linq;
using System.Windows;

namespace p_hello_cad
{
    /// <summary>
    /// شكل رباعي عام
    /// </summary>
    public class _c_quadrilateral
    {
        public Point[] s_pts_ = new Point[4];   // List of points
        public bool s_vld_ = true;              // Are all string inputs valid?

        /// <summary>
        /// defalut constructor
        /// </summary>
        public _c_quadrilateral() { }

        /// <summary>
        /// بتاخد نص على هيئة
        /// 000.000
        /// وبترجعلك رقم
        /// لو حصل خطأ هاتسجله في المتغير
        /// s_vld_
        /// </summary>
        /// <param name="p_str_">النص المدخل</param>
        /// <returns></returns>
        public double f_parse_number_(string p_str_)
        {
            try
            {
                return double.Parse(p_str_);
            }
            catch (Exception p_exp_)
            {
                s_vld_ = false;
                return 0;
            }
        }

        /// <summary>
        /// بتاخد نص على هيئة
        /// 000.000,000.000
        /// وبترجعلك نقطة
        /// </summary>
        /// <param name="p_str_">النص المدخل</param>
        /// <returns></returns>
        public Point f_parse_point_(string p_str_)
        {
            Point l_pnt_ = new Point();
            string[] l_crd_ = l_crd_ = p_str_.Split(",".ToArray());

            try
            {
                l_pnt_.X = f_parse_number_(l_crd_[0]);
                l_pnt_.Y = f_parse_number_(l_crd_[1]);
            }
            catch (Exception p_exp_)
            {
                s_vld_ = false;
            }

            return l_pnt_;
        }

        /// <summary>
        /// ياخد النقط واطوال الأضلاع
        /// ويعمل حسابات
        /// ويسجلها في المصفوفة
        /// </summary>
        /// <param name="p_pts_">النقط</param>
        /// <param name="p_val_">أطوال الأضلاع</param>
        public virtual void v_caluclate_(Point[] p_pts_, double[] p_val_)
        {
            s_pts_ = p_pts_;
        }

        /// <summary>
        /// ياخد الكلام اللي كان في مربعات النص
        /// ويحوله لنقط وأطوال أضلاع
        /// </summary>
        /// <param name="p_pts_">الكلام اللي مكتوب فيه النقط على هيئة نص</param>
        public virtual void v_load_text_(string[] p_pts_)
        {
            Point[] l_pts_ = new Point[4];
            for (int i_ndx_ = 0; i_ndx_ < 4; i_ndx_++)
            {
                l_pts_[i_ndx_] = f_parse_point_(p_pts_[i_ndx_]);
            }

            if (!s_vld_) { return; }
            v_caluclate_(l_pts_, null);
        }

        /// <summary>
        /// كل شكل ليه عناوين المدخلات اللي بيستقبلها
        /// الكود دة بيرجعلك قائمة بالعناوين
        /// كل شكل هايعمل
        /// override
        /// مناسب ليه
        /// </summary>
        /// <returns></returns>
        public virtual string[] f_lables_()
        {
            return new string[] {"النقطة 1","النقطة 2","النقطة 3","النقطة 4" };
        }
    }
}