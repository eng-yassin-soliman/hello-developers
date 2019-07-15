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
        [HttpGet]
        public string f_timenow_()
        {
            return DateTime.Now.ToString();
        }
    }
}