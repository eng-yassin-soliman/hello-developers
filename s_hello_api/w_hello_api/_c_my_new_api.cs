using Microsoft.AspNetCore.Mvc;
using System;

namespace w_hello_api
{
    [ApiController]
    public class _c_my_new_api : Controller
    {
        [HttpPost]
        int iii() { return 19; }
    }
}