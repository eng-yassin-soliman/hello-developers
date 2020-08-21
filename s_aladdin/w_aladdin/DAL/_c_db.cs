using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace w_aladdin
{
    public class _c_db : DbContext
    {
        #region "Boilerplate"

        public IDbContextTransaction s_tra_ { get; set; }   // Transaction
        public string s_msg_ { get; set; }                  // Error message

        public _c_db() 
        { s_msg_ = "ok"; }

        public Boolean f_open_()
        {
            try
            {
                Database.OpenConnection();
                s_tra_ = Database.BeginTransaction(IsolationLevel.Serializable);
                return true;
            }
            catch (Exception p_exp_)
            {
                s_msg_ = p_exp_.Message;
                return false;
            }
        }

        public Boolean f_save_()
        {
            try
            {
                SaveChanges();
                return true;
            }
            catch (DbUpdateException p_exp_)
            {
                s_msg_ = p_exp_.Message;
                return false;
            }
        }

        public Boolean f_close_(bool p_cmt_)
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
            {
                s_msg_ = p_exp_.Message;
                return false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { optionsBuilder.UseSqlServer("Server=localhost; Database=db_aladdin; User Id=sa; Password=123456aA&"); }
        #endregion

        #region "Tables"
        public virtual DbSet<_c_user> t_users { get; set; }
        protected override void OnModelCreating(ModelBuilder p_bld_)
        {   // Make c_name column unique
            p_bld_.Entity<_c_user>().HasIndex(p_ent_ => p_ent_.s_nam_).IsUnique();

            // Default value for c_date column = now
            p_bld_.Entity<_c_user>().Property(p_ent_ => p_ent_.s_dat_).HasDefaultValueSql("getdate()");
        }
        #endregion
    }
}