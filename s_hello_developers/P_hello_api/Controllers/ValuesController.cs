using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace P_hello_api.Controllers
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
    }
 }
