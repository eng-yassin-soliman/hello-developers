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
    [Route("hello/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> s_lst_ = new List<string>();
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }

        [HttpPost] 
            public string f_post_() { StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            return l_txt_;
        }




    }


}