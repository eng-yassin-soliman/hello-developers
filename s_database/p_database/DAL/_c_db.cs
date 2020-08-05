using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace p_database
{
    public class _c_db : DbContext
    {
        #region "Boilerplate"
        public Boolean f_open_()
        {
            Database.EnsureCreated();
            return true;
        }

        public Boolean f_close_()
        {
            Database.CloseConnection();
            return true; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=db_arbweb; User Id=sa; Password=123456aA&");
        }
        #endregion

        #region "Table"
        public virtual DbSet<_c_person> t_persons { get; set; }
        #endregion
    }
}