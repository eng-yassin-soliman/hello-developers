using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace w_aladdin
{
    public class _c_product
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }

        [Column("c_date")]          // Registration date and time
        public DateTime s_dat_ { get; set; }

        [Column("c_name")]
        public string s_nam_ { get; set; }

        [Column("c_price")]         // Price
        public double s_prc_ { set; get; }
    }
}