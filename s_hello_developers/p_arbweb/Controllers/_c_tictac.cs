using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Linq;

namespace p_arbweb
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