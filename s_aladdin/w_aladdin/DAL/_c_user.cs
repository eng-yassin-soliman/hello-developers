using System;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace w_aladdin
{
    [Table("t_users")]
    public class _c_user
    {
        [Key, Column("c_uid")]  // ID
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }

        [Column("c_date")]      // Registration date and time
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime s_dat_ { get; set; }

        [Column("c_name")]      // User login name
        public string s_nam_ { get; set; }

        [Column("c_password")]  // User password
        public string s_pas_ { get; set; }
    }
}