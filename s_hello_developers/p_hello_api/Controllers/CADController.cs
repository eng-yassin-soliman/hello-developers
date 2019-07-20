using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;
using System.IO;

namespace p_hello_api.Controllers
{
    class _c_drawing
    {
        public int s_uid_ = 0;
        public string s_nam_ = string.Empty;
        public string s_dat_ = string.Empty;
    }

    [Route("CAD/api")]
    [ApiController]
    public class CADController : Controller
    {
        List<_c_drawing> s_lst_ = new List<_c_drawing>;

        /// <summary>A method that returns the drawing data for all of the team</summary>
        /// <param name="p_drw_">The drawing data of the client</param>
        /// <returns>JSON formatted array of _c_drawing</returns>
        [HttpPost]
        public string f_post_(_c_drawing p_drw_)
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);

            string l_txt_ = l_red_.ReadToEnd();
            return l_txt_;
        }
    }
}