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
    public class _c_hello : Controller
    {
        /// <summary>
        /// HTTP GET Method runs on:
        /// http://localhost/hello/api/date
        /// </summary>
        /// <returns>Current date and time</returns>
        [HttpGet]
        [Route("date")]
        public DateTime f_date_()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// HTTP GET method runs on:
        /// http://localhost/hello/api/iot
        /// </summary>
        /// <returns>Random number</returns>
        [HttpGet]
        [Route("iot")]
        public int f_iot_()
        {
            Byte[] l_byt_ = { 0 };
            (new Random()).NextBytes(l_byt_);
            if (l_byt_[0] < 64) { return 0; }
            else if (l_byt_[0] < 128) { return 1; }
            else if (l_byt_[0] < 192) { return 10; }
            else { return 11; }
        }

        // Previous method
        /// <summary>
        /// HTTP POST method runs on:
        /// http://localhost/hello/api/iot
        /// Returns the same request body!!
        /// </summary>
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