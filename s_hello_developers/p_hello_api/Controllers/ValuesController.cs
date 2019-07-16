using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace p_hello_api.Controllers
{
    [Route("hello/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //// GET api/values
        //[HttpGet]
        //public string f_get_()
        //{
        //    return "hello";
        //}



        //byte l_byte = byte.TryParse(l_txt_, out p_num_1);
        // POST api/values
        [HttpPost]
        public string f_post_()
        {
            System.IO.StreamReader l_srd_ = new System.IO.StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            /*
            string l_txt_ = l_srd_.ReadToEnd();

            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_txt_);

    */

            string l_txt_ = l_srd_.ReadToEnd();
            byte byteValue;
            bool success = Byte.TryParse(l_txt_, out byteValue);
            string l_string = Encoding.UTF8.GetString(byteValue);












            StringBuilder l_str_ = new StringBuilder("");

            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString());
                l_str_.Append("--");
            }

            return l_str_.ToString();
        }
    }
}