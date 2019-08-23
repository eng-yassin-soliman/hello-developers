using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
namespace p_hello_api.DAL
{
    // Class represents a single member
    [Table("t_members")]
    public class _c_member
    {
        // A Primary key represents the record identifier,
        // We put that field in every table we create  
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; } // ID   
        [Column("c_name")]
        public string s_nam_ { get; set; }  // Name    
        [Column("c_password")]
        public string s_pas_ { get; set; }  // Password 
    }
}
