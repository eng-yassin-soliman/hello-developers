using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p_database
{
    [Table("t_persons")]
    public class _c_person
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }

        [Column("c_name")]
        public string s_nam_ { get; set; }

        [Column("c_gender")]
        public bool s_gnd_ { get; set; }

        [Column("c_birth_date")]
        public DateTime s_dat_ { get; set; }
    }
}