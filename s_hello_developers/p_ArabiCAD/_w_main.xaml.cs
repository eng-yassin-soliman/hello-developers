using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    public partial class _w_main : Window 
    {
        /// <summary>مصفوفة بالأدوات المتاحة، مثلا: خط مستقيم أو قوس</summary>
        public List<_c_tool> s_seg_ = new List<_c_tool>();

        /// <summary>المسار الحالي الجاري رسمه</summary>
        public Path s_pth_
        {
            get
            {
                if (b_lst_.SelectedIndex == -1) { return null; }
                return (Path)b_cnv_.Children[b_lst_.SelectedIndex];
            }
        }

        /// <summary>الشكل الحالي الجاري رسمه</summary>
        public PathFigure s_fig_
        {
            get
            {
                Path l_pth_ = s_pth_;
                if (l_pth_ == null) { return null; }
                PathGeometry l_geo_ = (PathGeometry)l_pth_.Data;
                return l_geo_.Figures[0];

                //if (b_lst_.SelectedIndex == -1) { return null; }
                //PathGeometry l_geo_ = (PathGeometry)s_pth_.Data;
                //return l_geo_.Figures[0];
            }
        }

        /// <summary>رقم المسار الجديد في القائمة</summary>
        public int s_num_ = 1;

        /// <summary>هل جار تعديل أي مسار؟</summary>
        public bool s_ena_
        {
            get
            {
                foreach (_c_tool i_seg_ in s_seg_)
                { if (i_seg_.s_chk_) { return false; } }
                return true;
            }
        }

        /// <summary>بداية البرنامج</summary>
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            s_seg_.Add(new _c_tol_lin(this));
            s_seg_.Add(new _c_tol_arc(this));

            foreach (_c_tool i_seg_ in s_seg_) { b_tol_.Children.Add(i_seg_.b_btn_); }

            b_pro_.s_man_ = this;
            b_lst_.SelectionChanged += new SelectionChangedEventHandler(v_selpath_);
        }

        /// <summary>عند النقر على زر إضافة مسار</summary>
        void v_addpath_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            if (!s_ena_) { return; }

            // إضافة مسار إلى لوحة الرسم
            Path l_pth_ = new Path();
            b_cnv_.Children.Add(l_pth_);

            l_pth_.StrokeStartLineCap = PenLineCap.Round;
            l_pth_.StrokeEndLineCap = PenLineCap.Round;
            l_pth_.StrokeLineJoin = PenLineJoin.Round;
            l_pth_.StrokeDashCap = PenLineCap.Round;

            l_pth_.Stroke = b_pro_.s_str_;
            l_pth_.Fill = b_pro_.s_fil_;
            l_pth_.StrokeThickness = b_pro_.s_thk_;
            l_pth_.StrokeDashArray = b_pro_.s_typ_;

            PathFigure[] l_fig_ = { new PathFigure() };
            l_fig_[0].IsClosed = b_pro_.s_cls_;
            PathGeometry l_geo_ = new PathGeometry(l_fig_);
            l_pth_.Data = l_geo_;

            // إضافة عنوان لقائمة العناوين
            TextBox l_ttl_ = new TextBox();
            b_lst_.Items.Add(l_ttl_);
            b_lst_.SelectedItem = l_ttl_;
            l_ttl_.Text = "مسار" + s_num_.ToString();
            l_ttl_.IsReadOnly = true;
            s_num_ += 1;
            l_ttl_.Padding = new Thickness(5);
        }

        /// <summary>عند النقر على زر حذف مسار</summary>
        void v_delpath_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            if (!s_ena_) { return; }

            int l_ndx_ = b_lst_.SelectedIndex;
            // لا يمكن حذف المسار إذا كانت القائمة فارغة
            if (l_ndx_ == -1) { return; }

            b_lst_.Items.RemoveAt(l_ndx_);
            b_cnv_.Children.RemoveAt(l_ndx_);
        }

        /// <summary>إضافة عنوان لقائمة العناصر</summary>
        public void v_element_()
        {
            TextBox l_ttl_ = new TextBox();
            b_itm_.Items.Add(l_ttl_);
            l_ttl_.Text = "قطعة " + b_itm_.Items.Count;
            l_ttl_.Padding = new Thickness(5);
            l_ttl_.IsReadOnly = true;
        }

        /// <summary>عند النقر على زر حذف عنصر</summary>
        public void v_delelmn_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            int l_ndx_ = b_itm_.SelectedIndex;
            if (l_ndx_ == -1) { return; }
            if (l_ndx_ != b_itm_.Items.Count - 1) { return; }

            b_itm_.Items.RemoveAt(l_ndx_);
            s_fig_.Segments.RemoveAt(l_ndx_);
        }

        /// <summary>عند تحديد مسار في قائمة المسارات</summary>
        void v_selpath_(object p_obj_, SelectionChangedEventArgs p_arg_)
        {
            b_itm_.Items.Clear(); 

            if (b_lst_.SelectedIndex == -1) { return; }
            foreach (PathSegment i_seg_ in s_fig_.Segments)
            { v_element_(); }

            b_pro_.v_refresh_();
        }

        /// <summary>لما تتحرك فوق لوحة الرسم يعرف مكانك فين ويكتب الاحداثيات</summary>
        void v_move_(object p_snd_, MouseEventArgs p_arg_)
        {
            if (s_ena_) { return; }

            b_cst_.v_update_(p_arg_.GetPosition(b_cnv_));
            foreach (_c_tool i_seg_ in s_seg_)
            {
                if (i_seg_.s_chk_)
                {
                    i_seg_.v_upd_(b_cst_.b_pnt_.s_val_);
                    return;
                }
            }
        }

        /// <summary>إضافة خط</summary>
        void v_addsegment_()
        {
            // يجب اختيار أداة لتفعيل إضافة خط
            if (s_ena_) { return; }

            _c_tool l_seg_ = new _c_tool();
            foreach (_c_tool i_seg_ in s_seg_)
            { if (i_seg_.s_chk_) { l_seg_ = i_seg_; break; } }
            l_seg_.v_add_();
        }

        /// <summary>لما تنقر على لوحة الرسم</summary>
        void v_addsegment_(object p_snd_, MouseButtonEventArgs p_arg_) { v_addsegment_(); }

        /// <summary>لما تضغط انتر</summary>
        void v_addsegment_(object p_snd_, RoutedEventArgs p_arg_) { v_addsegment_(); }

        /// <summary>Escape</summary>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            if (e.Key == Key.Escape)
            {
                foreach (_c_tool i_seg_ in s_seg_)
                {
                    if (i_seg_.s_chk_)
                    { i_seg_.v_uncheck_(); return; }
                }
            }
        }
    }
}