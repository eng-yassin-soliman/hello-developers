using System;
using Microsoft.AspNetCore.Mvc;

namespace p_hello_api
{
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api : Controller
    {
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }
    }
}