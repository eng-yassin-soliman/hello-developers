using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using

    namespace p_hello_api.Controllers
{
    [Route("hello/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> s_lst_ = new List<string>();

        [HttpPost]
        public string f_get_()
        {
            foreach (string i_str_ in s_lst_)
            {                
                string[] l_str_ = i_str_.split("-");
            }

            return "ok";
        }
    }
}