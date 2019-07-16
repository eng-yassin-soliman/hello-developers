using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;

namespace p_hello_api.Controllers
{
    public class _c_score
    {

    }

    [Route("hello/api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static List<string> s_lst_ = new List<string>();

        [HttpPost]
        public string f_get_()
        {
            //System.Net.IPAddress.
              //  ;
            //.MapToIPv4.ToString();

            for (int i_str_ = 0; i_str_ < s_lst_.Count; i_str_++)
            {


                System.IO.StreamReader l_srd_ = new System.IO.StreamReader(HttpContext.Request.Body,Encoding.UTF8);

                string l_txt_ = l_srd_.ReadToEnd();
                string[] l_str_ = s_lst_[i_str_].Split("-");
                string[] l_req_ = l_txt_.Split("-");

                if (l_str_[0] == l_req_[0])
                {
                    s_lst_[i_str_] = l_txt_;
                }
                else
                {
                    s_lst_.Add(l_txt_);
                };
            }

            return "ok";
        }
    }
}