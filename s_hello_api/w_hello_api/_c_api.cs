using Microsoft.AspNetCore.Mvc;
using System;

// 2020-07-09 02:25 PM GMT+2

namespace w_hello_api
{
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api : Controller
    {
        [Route("date")]
        [HttpPost]
        public DateTime f_date_()
        {
            return DateTime.Now;
        }
       
        [Route("name")]
        [HttpPost]
        public string f_name_()
        {
            return "yassin";
        }
    }
}