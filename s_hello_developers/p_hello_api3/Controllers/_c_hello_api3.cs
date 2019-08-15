using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
namespace p_hello_api3
{
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api3 : Controller
    {
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }
    }
}


