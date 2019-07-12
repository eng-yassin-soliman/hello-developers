using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace p_ArabiCAD
{
    /// <summary>Base class for _c_tools</summary>
    public class _c_tool
    {
        public _w_main s_man_;

        /// <summary>UI element</summary>
        public Border b_btn_ = new Border();
        public Path s_pth_ = new Path();

        /// <summary>General type for different segments</summary>
        public PathSegment s_seg_;

        /// <summary>Is the tool selected?</summary>
        public bool s_chk_ = false;

        /// <summary>Maded changes?</summary>
        public bool s_chg_ = false;

        public _c_tool() { }

        public _c_tool(_w_main p_man_)
        {
            s_man_ = p_man_;
            b_btn_.Child = s_pth_;
            b_btn_.MouseUp += new MouseButtonEventHandler(v_click_);
        }

        public void v_click_(object p_snd_, MouseButtonEventArgs p_arg_)
        {
            if (s_chk_) { v_uncheck_(); }
            else { v_check_(); }
        }

        public void v_check_()
        {
            if (!s_man_.s_ena_) { return; }

            if (s_man_.b_lst_.SelectedIndex == -1)
            {
                MessageBox.Show("يجب تحديد مسار أولا");
                return;
            }

            s_man_.b_lst_.IsEnabled = false;
            s_man_.b_itm_.IsEnabled = false;
            b_btn_.Background = Brushes.Cornsilk;
            s_man_.b_cst_.b_pnt_.b_ttl_.Text = "النقطة التالية";
            s_man_.b_cst_.Visibility = Visibility.Visible;

            s_chk_ = true;
        }

        public void v_uncheck_()
        {
            if (s_chg_) { v_del_(); s_chg_ = false; }
            
            b_btn_.Background = Brushes.White;
            s_man_.b_cst_.Visibility = Visibility.Collapsed;
            s_man_.b_lst_.IsEnabled = true;
            s_man_.b_itm_.IsEnabled = true;
            s_chk_ = false;
        }

        /// <summary>إضافة خط</summary>
        public virtual void v_add_() { }

        /// <summary>حذف خط</summary>
        public void v_del_()
        {
            int l_cnt_ = s_man_.s_fig_.Segments.Count;
            if (l_cnt_ == 0) { return; }

            s_man_.s_fig_.Segments.RemoveAt(l_cnt_ - 1);
            s_man_.b_itm_.Items.RemoveAt(l_cnt_ - 1);

            s_man_.b_cst_.Visibility = Visibility.Collapsed;
        }

        /// <summary>تحديث النقطة من على لوحة الرسم</summary>
        /// <param name="p_pnt_">موقع المؤشر فوق لوحة الرسم</param>
        public virtual void v_upd_(Point p_pnt_) { }
    }
}