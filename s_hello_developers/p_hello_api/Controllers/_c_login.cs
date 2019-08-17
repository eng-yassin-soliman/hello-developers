using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using p_hello_api.DAL;

namespace p_hello_api.Controllers
{
    [ApiController]
    [Route("login")]
    public class _c_login : Controller
    {
        [HttpPost]
        [Route("signup")]
        public string f_signup_(_c_member p_mem_)
        {
            if (p_mem_.s_nam_ == null | p_mem_.s_nam_.Length < 3 | p_mem_.s_pas_.Length > 30)
            { return "اسم الدخول يجب ألا يقل عن 3 أحرف و لا يزيد عن 30 حرف"; }


            if (p_mem_.s_pas_ == null | p_mem_.s_pas_.Length < 6 | p_mem_.s_pas_.Length > 30)
            { return "كلمة المرور يجب ألا تقل عن 6 أحرف و ألا تزيد عن 30 حرف"; }

            _c_dal l_dal_ = new _c_dal();
            l_dal_.f_open_();
            _c_member l_mem_ = new _c_member();
            l_mem_.s_nam_ = p_mem_.s_nam_;
            l_mem_.s_pas_ = p_mem_.s_pas_;
            l_dal_.Entry(l_mem_).State = EntityState.Added;
            if (!l_dal_.f_save_())
            {
                l_dal_.f_close_(false);
                return l_dal_.s_err_;
            }
            if (!l_dal_.f_close_(true))
            {
                return "Error";
            }
            return "1"; // OK
        }
        [HttpPost]
        [Route("login")]
        public string f_login_(_c_member p_mem_)
        {
            string l_rtr_ = string.Empty; // Message to return
            _c_dal l_dal_ = new _c_dal();
            l_dal_.f_open_();
            _c_member[] q_mem_ = (from _c_member i_mem_ in l_dal_.t_members
                                  where
                                  i_mem_.s_nam_ == p_mem_.s_nam_ &&
                                  i_mem_.s_pas_ == p_mem_.s_pas_
                                  select i_mem_).ToArray();
            if (!q_mem_.Any())
            {
                l_rtr_ = "خطأ فى الاسم أو كلمة المرور";
                goto n_final_;
            }
            _c_member l_mem_ = q_mem_.First();
            // Save the user id at the client’s browser
            HttpContext.Response.Cookies.Append("c_uid_", l_mem_.s_uid_.ToString());
            l_rtr_ = "1"; // Login successful!
        n_final_:
            l_dal_.f_close_(true);
            return l_rtr_;
        }

    }
}
