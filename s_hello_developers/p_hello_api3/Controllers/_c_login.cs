using System;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using p_hello_api3.DAL;

namespace p_hello_api3.Controllers
{ 
    [ApiController]
    [Route("login")]
    public class _c_login: Controller
    {
        [HttpPost]
        [Route("signup")]
        public string f_signup_(_c_member p_mem_)
        {
            if(p_mem_.s_nam_ == null | p_mem_.s_nam_.Length < 3 | p_mem_.s_pas_.Length > 30)
            {
                return "اسم الدخول يجب ان لا يقل عن 3 احرف و لا يزيد عن 30 حرف";
            }
            if(p_mem_.s_pas_ ==null | p_mem_.s_pas_.Length < 6 | p_mem_.s_pas_.Length > 30)
            {
                return "كلمة المرور يجب ان لا تقل عن 6 احرف و لا تزيد عن 30 حرف";
           
            }
            _c_dal l_dal_ =new _c_dal();
            l_dal_.f_open_();
            _c_member l_mem_ = new _c_member();
            l_mem_.s_nam_ = p_mem_.s_nam_;
            l_mem_.s_pas_ = p_mem_.s_pas_;
            l_dal_.Entry(l_mem_).State = EntityState.Added;
            if(!l_dal_.f_save_())
            {
                l_dal_.f_close_(false);
                return l_dal_.s_err_;
            }
            if(!l_dal_.f_close_(true))
            {
                return"Error";
            }
            return "1";
            // OK
        }

    }
    
}
