using System.Windows;
using System.Windows.Controls;

namespace p_ArabiCAD
{
    public partial class _b_constraints : UserControl
    {
        public _b_constraints() { InitializeComponent(); }

        public void v_update_(Point p_pnt_)
        {
            b_pnt_.b_xcr_.s_val_ = p_pnt_.X;
            b_pnt_.b_ycr_.s_val_ = p_pnt_.Y;
        }
    }
}