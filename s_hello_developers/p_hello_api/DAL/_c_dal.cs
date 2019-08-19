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
                Database.EnsureCreated(); // Create database if not created
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
                { s_tra_.Commit(); }
                else
                { s_tra_.Rollback(); }
                Database.CloseConnection();
                return true;
            }
            catch (Exception p_exp_)
            { return false; }
        }
        // Connection string: the host where engine resides, DB name, user credentials, etc...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseMySQL("Server=localhost;database=db_arbweb;Uid=root;Pwd=123456aA&");
        }
        // A table of members
        public virtual DbSet<_c_member> t_members { get; set; }
        // Make sure the user name is unique (No repetition)
        protected override void OnModelCreating(ModelBuilder p_bld_)
        {
            p_bld_.Entity<_c_member>().HasIndex(p_ent_ => p_ent_.s_nam_).IsUnique();
        }
    }
}
