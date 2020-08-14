using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Windows;

namespace w_aladdin
{
    public class _c_db : DbContext
    {
        #region "Boilerplate"
        public Boolean f_open_()
        {
            Database.EnsureCreated();   // 1- open connection
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
            optionsBuilder.UseSqlServer("Server=localhost; Database=db_aladdin; User Id=sa; Password=123456aA&");
        }
        #endregion

        #region "Tables"
        public virtual DbSet<_c_user> t_users { get; set; }
        #endregion
    }
}