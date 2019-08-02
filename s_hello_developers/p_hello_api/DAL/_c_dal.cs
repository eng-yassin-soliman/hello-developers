using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace p_hello_api.DAL
{
    public class _c_dal
    {
        Boolean f_connect_()
        {            
            using (MySqlConnection l_con_ = new MySqlConnection(""))
            {
                using (MySqlTransaction l_tra_ = l_con_.BeginTransaction(System.Data.IsolationLevel.Serializable))
                {
                    _c_ctx l_ctx_ = new _c_ctx();
                    
                }
            }


            return true;
        }
    }

    public class _t_member
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_uid_ { get; set; }
        public string c_name_ { get; set; }
        public DateTime c_birth_ { get; set; }
    }

    public class _c_ctx : DbContext
    {
        public virtual DbSet<_t_member> Enrollments { get; set; }
    }
}