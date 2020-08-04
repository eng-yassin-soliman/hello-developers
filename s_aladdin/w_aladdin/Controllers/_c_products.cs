using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// 2020-07-09 02:25 PM GMT+2

namespace w_aladdin
{
    public class _c_product
    {
        public string s_nam_ { set; get; }  // Name
        public double s_prc_ { set; get; }  // Price
    }

    [Route("products")]
    [ApiController]
    public class _c_products : Controller
    {
        [HttpPost]
        [Route("list")]
        public List<_c_product> f_text_()
        {
            List<_c_product> l_lst_ = new List<_c_product>();
            l_lst_.Add(new _c_product() { s_nam_ = "p1", s_prc_ = 1.1 });
            l_lst_.Add(new _c_product() { s_nam_ = "p2", s_prc_ = 2.2 });
            l_lst_.Add(new _c_product() { s_nam_ = "p3", s_prc_ = 3.3 });

            return l_lst_;
        }
    }
}