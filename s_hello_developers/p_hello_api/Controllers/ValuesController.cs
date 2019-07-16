using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;

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
            return "";
        }
    }
}