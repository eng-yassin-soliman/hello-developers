using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Net;
using System.IO;
using Remotion.Linq.Clauses.ExpressionVisitors;

namespace p_hello_api.Controllers
{
    public class _c_drawing
    {
        public int s_uid_ = 0;                  // ID
        public string s_nam_ = string.Empty;    // Name
        public string s_dat_ = string.Empty;    // Drawing data
        public string s_lin_ = string.Empty;    // Line color
        public string s_fil_ = string.Empty;    // Filling color of the shape
    }

    [Route("CAD/api")]
    [ApiController]
    public class CADController : Controller
    {
        static List<_c_drawing> s_lst_ = new List<_c_drawing>();

        /// <summary>A method that returns the drawing data for all of the team</summary>
        /// <param name="p_drw_">The drawing data of the client</param>
        /// <returns>JSON formatted array of _c_drawing</returns>
        [HttpPost]
        public _c_drawing[] f_post_(_c_drawing p_drw_)
        {
            // check if uid exists in the array
            var l_qur_ = (from q_drw_ in s_lst_
                          where q_drw_.s_uid_ == p_drw_.s_uid_
                          select q_drw_);

            if (!l_qur_.Any())
            {
                s_lst_.Add(p_drw_);
            }
            else
            {
                int l_ndx_;
                l_ndx_ = s_lst_.IndexOf(l_qur_.FirstOrDefault());
                s_lst_[l_ndx_] = p_drw_;
            }

            return s_lst_.ToArray();
        }
    }
}