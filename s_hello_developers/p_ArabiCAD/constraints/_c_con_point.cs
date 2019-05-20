using System.Windows;

namespace p_ArabiCAD.constraints
{
    /// <summary>The type of point</summary>
    public enum _e_point
    {
        /// <summary>With coordinates</summary>
        e_0ext_,
        /// <summary>Intersection with line</summary>
        e_1lin_,
        /// <summary>First intersection with arc extension</summary>
        e_2ar1_,
        /// <summary>Second intersection with arc extension</summary>
        e_3ar2_
    }

    public class _c_con_point : _c_constraint
    {
        public _e_point s_typ_ = _e_point.e_0ext_;

        public _c_con_point() { }

        public Point f_value_()
        {
            switch (s_typ_)
            {
                case _e_point.e_0ext_:
                    return new Point(s_val_[0], s_val_[1]);

                case _e_point.e_1lin_:
                    break;

                case _e_point.e_2ar1_:
                    break;

                case _e_point.e_3ar2_:
                    break;

                default:
                    break;
            }

            return new Point();
        }
    }
}