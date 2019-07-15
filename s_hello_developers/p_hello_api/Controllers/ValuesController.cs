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
            System.IO.StreamReader l_srd_ = new System.IO.StreamReader(HttpContext.Request.Body, Encoding.UTF8);

            int l_lng_ = int.Parse(HttpContext.Request.Headers["content-length"].ToString());

            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_srd_.ReadToEnd());

            StringBuilder l_str_ = new StringBuilder("");

            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString());
                l_str_.Append(" - ");
            }

            return l_str_.ToString();
        }
    }
}