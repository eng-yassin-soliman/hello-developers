using System.Windows;

namespace p_ArabiCAD
{
    public partial class _c_app : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _c_app.v_new_("");
        }

        public static void v_new_(string p_loc_)
        {
            _w_main l_man_ = new _w_main(p_loc_);
            l_man_.Show();
        }
    }
}