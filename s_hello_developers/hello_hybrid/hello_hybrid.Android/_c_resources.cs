using hello_hybrid.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(_c_resources))]
namespace hello_hybrid.Droid
{
    public class _c_resources : _i_resources
    {
        public string f_url_()
        {
            return "file:///android_asset/html/index.html";
        }
    }
}