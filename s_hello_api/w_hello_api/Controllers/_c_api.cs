using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;

// 2020-07-09 02:25 PM GMT+2

namespace w_hello_api
{
    public class _c_add_parameters
    {
        public int s_1st_ { get; set; }
        public int s_2nd_ { get; set; }
    }
     
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api : Controller
    {
        [HttpGet]
        [Route("add")]
        public int f_add_(_c_add_parameters p_par_)
        {
            return p_par_.s_1st_ + p_par_.s_2nd_;
        }

        [HttpGet]
        [Route("text")]
        public string f_text_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEndAsync().Result;

            return l_txt_;
        }

        [HttpGet]
        [Route("byte")]
        public string f_byte_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEndAsync().Result;

            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_txt_);
            StringBuilder l_str_ = new StringBuilder(string.Empty);

            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString("000"));
                l_str_.Append(Encoding.UTF8.GetString(new byte[] { 10 })); // New line
            }

            return l_str_.ToString();
        }
    }
}