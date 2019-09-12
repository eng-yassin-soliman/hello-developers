using System;
using System.Collections.Generic;
using System.Text;

namespace hello_hybrid
{
    // Because the embedded resource url is different for each platform
    public interface _i_resources
    {
        string f_url_();
    }
}