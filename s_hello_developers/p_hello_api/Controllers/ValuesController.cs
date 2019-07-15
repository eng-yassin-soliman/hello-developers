using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace p_hello_api.Controllers
{
    [Route("hello/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> l_lst_ = new List<string>();

        [HttpPost]
        public string f_get_()
        {

        }
    }
}