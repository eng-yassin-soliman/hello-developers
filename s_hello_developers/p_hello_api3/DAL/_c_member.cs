using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace p_hello_api3.DAL
{
    [Table("t_members")] 
    public class _c_member
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_
        {
            get;
            set;
        }
        [Column("c_name")] 
        public string s_nam_
        {
            get;
            set;
        }
        // Name
        [Column("c_password")]
        public string s_pas_
        {
            get;
            set;
        }
    }
}
