using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using p_hello_api.DAL;

namespace p_arbweb
{
    [ApiController]
    [Route("login")]
    public class _c_login : Controller
    {
        [HttpPost]
        [Route("submit")]
        public string f_login_(_c_member p_mem_)
        {
            _c_member l_mem_ = new _c_member(p_mem_.s_nam_, p_mem_.s_pas_);

            _c_ctx l_dal_ = new _c_ctx();
            l_dal_.f_connect_();
            l_dal_.Entry(l_mem_).State = EntityState.Added;

            if (l_dal_.f_close(true))
            {
                return "0";
            }
            else
            {
                return "Error: " + l_dal_.s_err_;
            }
        }
    }
}