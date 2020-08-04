using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace p_database.DAL
{


    class _c_db :  DbContext
    {
        public Boolean f_open_()
        {
            Database.EnsureCreated();
            return true;
        }

        public Boolean f_close_()
        {
            return true;
        }

        // Connection string: the host where engine resides, DB name, user credentials, etc...
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=db_arbweb; User Id=sa; Password=123456aA&");
        }
    }
}