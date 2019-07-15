using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace p_hello_api.Controllers
{
    public class _c_person
    {
        public string s_nam_ { get; set; }
        public int s_age_ { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string f_get_()
        {
            return "new";
        }

        // POST api/values
        [HttpPost]
        public string v_post_()
        {
            // public string v_post_(_c_person p_per_)
            // Request
            // Raw
            // application/json
            //{
            //    "s_nam_": "yassin",
            //    "s_age_": 34
            //}
            // return p_per_.s_nam_ + " - " + p_per_.s_age_.ToString();

            System.IO.StreamReader l_srd_ = new System.IO.StreamReader(HttpContext.Request.Body, Encoding.ASCII);

            int l_lng_ = int.Parse(HttpContext.Request.Headers["content-length"].ToString()); // l_red_.ReadToEnd()

            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_srd_.ReadToEnd());

            string l_str_ = "";

            foreach (byte i_byt_ in l_byt_)
            {
                l_str_ = l_str_ + " - " + i_byt_.ToString();
            }

            return l_str_;
        }
    }
}