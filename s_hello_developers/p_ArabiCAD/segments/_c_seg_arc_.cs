using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    class _c_seg_arc_ : _c_segment
    {
        public _c_seg_arc_(_w_main p_man_) : base(p_man_)
        {
            // arc segment to draw
            s_seg_ = new ArcSegment();

            // Contents of button to draw
            ArcSegment[] l_arc_ = 
                { new ArcSegment(new Point(15, 15), new Size(14, 14),
                0, false, SweepDirection.Clockwise, true) };

            PathFigure[] l_fig_ =
                { new PathFigure(new Point(2, 2), l_arc_, false) };
            PathGeometry l_geo_ = new PathGeometry(l_fig_);
            s_pth_.Data = l_geo_;
        }

        public override void v_add_()
        {
            // اضافة الخط إلى لوحة الرسم
            ArcSegment l_seg_ = new ArcSegment();
            l_seg_.Point = s_man_.b_cst_.b_pnt_.s_val_;
            s_seg_ = l_seg_;

            l_seg_.Size = new Size(100, 100);

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
                ((ArcSegment)s_seg_).Point = p_pnt_;
            }
        }
    }
}