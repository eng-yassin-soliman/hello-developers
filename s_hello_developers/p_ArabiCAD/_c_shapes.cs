using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

abstract public class _c_shape
{
    public SolidColorBrush s_brs_;  // Pen Color
    public double s_thk_;           // Pen Thickness

    public _c_shape(SolidColorBrush p_brs_, double p_thk_)
    {
        s_brs_ = p_brs_;
        s_thk_ = p_thk_;
    }

    public abstract void v_draw_(Canvas p_cnv_);

    public void v_add_(Canvas p_cnv_)
    {
        // code before

        v_draw_(p_cnv_);

        // code after
    }
}

public class _c_line : _c_shape
{
    public Point s_pt1_;
    public Point s_pt2_;

    public _c_line(SolidColorBrush p_brs_, double p_thk_,
        Point p_pt1_, Point p_pt2_) : base(p_brs_, p_thk_)
    {
        s_pt1_ = p_pt1_;
        s_pt2_ = p_pt2_;
    }

    public _c_line(SolidColorBrush p_brs_, double p_thk_,
        Point p_pt1_, double p_ang_, double p_lnt_) : base(p_brs_, p_thk_)
    {
        s_pt1_ = p_pt1_;

        double l_ang_ = (p_ang_ * Math.PI) / 180;
        double l_xcr_ = s_pt1_.X + Math.Cos(l_ang_);
        double l_ycr_ = s_pt1_.Y + Math.Sin(l_ang_);
        s_pt2_ = new Point(l_xcr_, l_xcr_);
    }

    public override void v_draw_(Canvas p_cnv_)
    {
        Line l_lin_ = new Line();
        l_lin_.Stroke = s_brs_;
        l_lin_.StrokeThickness = s_thk_;
        l_lin_.X1 = s_pt1_.X;
        l_lin_.X2 = s_pt2_.X;
        l_lin_.Y1 = s_pt1_.Y;
        l_lin_.Y2 = s_pt2_.Y;

        p_cnv_.Children.Add(l_lin_);
    }
}

public class _c_circle : _c_shape
{
    public Point s_ctr_;            // Center
    public Double s_rad_;           // Radius

    public _c_circle(SolidColorBrush p_brs_, double p_thk_,
        Point p_ctr_, Double p_rad_) : base(p_brs_, p_thk_)
    {
        s_ctr_ = p_ctr_;
        s_rad_ = p_rad_;
    }

    public override void v_draw_(Canvas p_cnv_)
    {


    }
}