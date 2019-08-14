using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;
using p_hello_api.DAL;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;

namespace p_hello_api.Controllers
{
    [ApiController]
    [Route("tictac")]
    public class _c_tictac : Controller
    {
        [HttpPost]
        [Route("list")]
        public _c_game[] f_list_(_c_game p_gam_)
        {
            return new _c_game[] { };
        }
    }
}