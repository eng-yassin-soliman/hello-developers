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
    public class ValuesController : Controller
    {
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }

        // Previous method

        /// <summary>A simple method that returns the same request body!!</summary>
        /// <returns>String with the contents of request body</returns>
        [HttpPost]
        public string f_post_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);

            string l_txt_ = l_red_.ReadToEnd();
            return l_txt_;
        }
    }
}