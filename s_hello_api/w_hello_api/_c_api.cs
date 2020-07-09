﻿using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;

// 2020-07-09 10:41 PM GMT+2

namespace w_hello_api
{
    [Route("hello/api")]
    [ApiController]
    public class _c_hello_api : Controller
    {
        // API
        // Which does not retur a GUI (HTML for example)
        [Route("date")]
        [HttpGet]
        public string f_date_()
        {
            return DateTime.Now.ToString();
        }

        [Route("name")]
        [HttpGet]
        public string f_name_()
        { return "yassin"; }
    }
}