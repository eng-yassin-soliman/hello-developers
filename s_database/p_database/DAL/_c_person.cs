using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_database.DAL
{
    [Table("t_persons")]
    class _c_person
    {
        [Column("c_name")]
        public string s_nam_ { get; set; }
        [Column("c_name")]
        public bool s_gnd_ { get; set; }
        [Column("c_name")]
        public DateTime s_dat_ { get; set; }      
    }
}