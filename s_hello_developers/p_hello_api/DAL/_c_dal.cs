using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

namespace p_hello_api.DAL
{
    // Database connection
    public class _c_dal
    {
        _c_ctx s_ctx_;
        IDbContextTransaction s_tra_;

        public Boolean f_connect_()
        {
            s_ctx_ = new _c_ctx();
            s_tra_ = s_ctx_.Database.BeginTransaction(IsolationLevel.Serializable);
            return true;
        }

        public Boolean f_close(Boolean p_cmt_)
        {
            if (p_cmt_)
            {
                s_tra_.Commit();
            }
            else
            {
                s_tra_.Rollback();
            }

            s_ctx_.Database.CloseConnection();
            return true;
        }
    }

    // The database
    public class _c_ctx : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Database=db_engasu;Uid=root;Pwd=123456aA&");
        }

        // A table of members
        public virtual DbSet<_t_member> _t_members { get; set; }
    }

    // Class represents a single member
    public class _t_member
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int c_uid_ { get; set; }         // Primary key
        public string c_email_ { get; set; }    // Email
        public string c_name_ { get; set; }     // Name
        public DateTime c_birth_ { get; set; }  // Date of birth
    }
}