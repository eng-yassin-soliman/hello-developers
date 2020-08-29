using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Windows;

namespace p_database
{
    public class _c_db : DbContext
    {
        #region "Boilerplate"
        public Boolean f_open_()
        {
            Database.EnsureCreated();   // 1- open connectio
                                        // 2- create db (if not allready created)

            return true;
        }

        public Boolean f_close_()
        {
            Database.CloseConnection();
            return true; 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=db_arbweb; Usr Id=sa; Password=123456aA&");
        }
        #endregion

        #region "Tables"
        public virtual DbSet<_c_person> t_persons { get; set; }
        #endregion
    }
}