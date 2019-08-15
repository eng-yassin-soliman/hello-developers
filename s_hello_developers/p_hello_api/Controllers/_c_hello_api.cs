using System; 
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Mvc;
namespace p_hello_api {
    [Route("hello/api")] 
    [ApiController] 
    public class _c_hello_api : Controller     {
        // Previous method ... ... 
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
        public string f_byte_(){
            StreamReader l_red_ = new StreamReader(HttpContext.Request.Body, Encoding.UTF8);
            string l_txt_ = l_red_.ReadToEnd();
            byte[] l_byt_ = Encoding.UTF8.GetBytes(l_txt_);
            StringBuilder l_str_ = new StringBuilder(string.Empty);
            foreach (byte i_byt_ in l_byt_)
            {
                l_str_.Append(i_byt_.ToString("000"));
                l_str_.Append(Encoding.UTF8.GetString(new byte[] { 10 }));
                // New line           
            } return l_str_.ToString();
        }
    }
}