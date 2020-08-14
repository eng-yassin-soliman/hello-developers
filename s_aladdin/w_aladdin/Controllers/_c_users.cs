using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace w_aladdin
{
    [Route("users")]
    [ApiController]
    public class _c_users : Controller
    {
        _c_db s_dal_ = new _c_db();

        [HttpGet]
        [Route("list")]
        public List<_c_user> f_text_(int p_skp_, int p_tak_)
        {
            List<_c_user> l_lst_ = new List<_c_user>();

            s_dal_.f_open_();
            l_lst_ = (from i_usr_ in s_dal_.t_users
                      orderby i_usr_.s_dat_ descending
                      select i_usr_).Skip(p_skp_).Take(p_tak_).ToArray().ToList();
            s_dal_.f_close_();

            return l_lst_;
        }
    }
}