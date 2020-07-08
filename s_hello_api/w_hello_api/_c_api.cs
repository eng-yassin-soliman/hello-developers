using Microsoft.AspNetCore.Mvc;
using System;

namespace w_hello_api
{
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api : Controller
    {
        // API
        // Which does not retur a GUI (HTML for example)
        [Route("date")]
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }
       
        [Route("name")]
        [HttpGet]
        public string f_name_()
        { return "yassin"; }
    }
}