using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace p_hello_api
{
    [Route("hello/api")] 
    [ApiController] 
    public class _c_hello_api : Controller
    {
        [HttpPost]
        [Route("text")]
        public string f_text_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            return l_txt_;
        }

        [HttpPost]
        [Route("byte")]
        public string f_byte_()
        {
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_txt_);
            StringBuilder l_str_ = new StringBuilder(string.Empty);
            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString("000"));
                l_str_.Append(Encoding.UTF8.GetString(new byte[] { 10 }));
                // New line           
            }
            return l_str_.ToString();
        }


        // Sending and recieving complex objects as JSON
        public class _c_complex
        {
            public string s_str_ = string.Empty;

            // Workaround for proper serializing of byte array
            [JsonConverter(typeof(_c_js_ar_byte))]
            public byte[] s_byt_ = { };
        }

        [HttpPost]
        [Route("json")]
        public _c_complex f_json_(_c_complex p_cpx_)
        {
            return p_cpx_; // Return the same object recieved!
        }
    }
}