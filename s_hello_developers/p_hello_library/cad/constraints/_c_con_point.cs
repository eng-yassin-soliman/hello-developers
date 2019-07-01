using System;
using System.Drawing;
using System.Windows;

namespace p_ArabiCAD.constraints
{
    /// <summary>Helper calss for some calculations</summary>
    public static class _c_math
    {
        /// <summary>Returns radian angle from a given degrees angle</summary>
        /// <param name="p_dgr_">Angle in degrees</param>
        public static double f_radian_(double p_dgr_)
        { return Math.PI * (p_dgr_ / (double)180); }
    }

    public struct _c_point
    {
        /// <summary>X Coordinate</summary>
        double s_xcr_;
        /// <summary>Y Coordinate</summary>
        double s_yxr_;

        public _c_point(double p_xcr_, double p_ycr_)
        {
            s_xcr_ = 0;
            s_yxr_ = 0;
        }

        /// <summary>Returns a point at distance and direction from an original point</summary>
        /// <param name="p_org_">Original point</param>
        /// <param name="p_dst_">Distance from original</param>
        /// <param name="p_ang_">Direction</param>
        public _c_point f_dist_angl_(double p_dst_, double p_ang_)
        {
            double l_xcr_ = s_xcr_ + (p_dst_ * Math.Cos(_c_math.f_radian_(p_ang_)));
            double l_ycr_ = s_yxr_ + (p_dst_ * Math.Sign(_c_math.f_radian_(p_ang_)));

            return new _c_point(l_xcr_, l_ycr_);
        }
    }

    /// <summary>Point constraint</summary>
    public enum _e_point
    {
        /// <summary>By coordinates</summary>
        e_0crd_,
        /// <summary>Intersection with line</summary>
        e_1lin_,
        /// <summary>First intersection with arc extension</summary>
        e_2ar1_,
        /// <summary>Second intersection with arc extension</summary>
        e_3ar2_
    }

    public abstract class _c_con_point : _c_constraint
    {
        public _e_point s_typ_ = _e_point.e_0crd_;

        public _c_con_point() { }

        public abstract _c_point f_value_();
    }

    public class _c_con_fixed : _c_con_point
    {
        /// <summary>ترجع الإحداثيات الثابتة للنقطة</summary>
        public override _c_point f_value_()
        {
            return new _c_point(s_val_[0], s_val_[1]);
        }
    }
}