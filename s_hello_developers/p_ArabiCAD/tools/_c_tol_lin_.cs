using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    public class _c_tol_lin : _c_tool
    {
        public _c_tol_lin(_w_main p_man_) : base(p_man_)
        {
            // line segment to draw
            s_seg_ = new LineSegment();

            // Contents of button to draw
            LineGeometry l_lin_ = new LineGeometry(new Point(3, 3), new Point(15, 15));
            s_pth_.Data = l_lin_;
        }

        public override void v_add_()
        {
            // اضافة الخط إلى لوحة الرسم
            LineSegment l_seg_ = new LineSegment();
            l_seg_.Point = s_man_.b_cst_.b_pnt_.s_val_;
            s_seg_ = l_seg_;
            
            s_man_.s_fig_.Segments.Add(s_seg_);
            s_man_.v_element_();

            s_chg_ = true;
        }

        public override void v_upd_(Point p_pnt_)
        {
            if (s_man_.s_fig_.Segments.Count == 0)
            {
                s_man_.s_fig_.StartPoint = p_pnt_;
            }
            else
            {
                ((LineSegment)s_seg_).Point = p_pnt_;
            }
        }
    }
}