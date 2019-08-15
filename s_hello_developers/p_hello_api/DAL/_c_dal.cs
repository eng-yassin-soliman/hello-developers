using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.Migrations;
using Microsoft.AspNetCore.Authentication;

// Data Access Layer
namespace p_hello_api.DAL
{
    // The database
    public class _c_dal : DbContext
    {
        public IDbContextTransaction s_tra_;
        public string s_err_ = string.Empty;

        // Connect to database, create if no exists
        public Boolean f_open_()
        {
            try
            {
                Database.EnsureCreated();   // Create database if no created
                s_tra_ = Database.BeginTransaction(IsolationLevel.Serializable);
                return true;
            }
            catch (Exception p_exp_)
            {
                return false;
            }
        }

        // Try save changes
        public Boolean f_save_()
        {
            try
            {
                SaveChanges();
                return true;
            }
            catch (DbUpdateException p_exp_)
            {
                s_err_ = p_exp_.InnerException.Message;
                return false;
            }
        }

        // Close the connection, commit or rollback the transaction
        public Boolean f_close_(Boolean p_cmt_)
        {
            try
            {
                if (p_cmt_)
                {
                    s_tra_.Commit();
                }
                else
                {
                    s_tra_.Rollback();
                }

                Database.CloseConnection();
                return true;
            }
            catch (Exception p_exp_)
            {
                return false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;database=db_arbweb;Uid=root;Pwd=123456aA&");
        }

        // Specify additional attributes for columns
        protected override void OnModelCreating(ModelBuilder p_bld_)
        {
            // Ensure the column "c_name" in the table "t_members" is unique (no repetitions)
            p_bld_.Entity<_c_member>().HasIndex(p_ent_ => p_ent_.s_nam_).IsUnique();
        }

        // A table of members
        public virtual DbSet<_c_member> t_members { get; set; }
    }

    // Class represents a single member
    [Table("t_members")]
    public class _c_member
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }    // ID

        [Column("c_name")]
        public string s_nam_ { get; set; }  // Name

        [Column("c_password")]
        public string s_pas_ { get; set; }  // Password

        public _c_member() { }

        public _c_member(string p_nam_, string p_pas_)
        {
            s_nam_ = p_nam_;
            s_pas_ = p_pas_;
        }
    }
}