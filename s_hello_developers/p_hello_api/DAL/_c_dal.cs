using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.Migrations;
using Microsoft.AspNetCore.Authentication;

namespace p_hello_api.DAL
{
    // The database
    public class _c_ctx : DbContext
    {
        IDbContextTransaction s_tra_;
        public string s_err_ = string.Empty;

        public Boolean f_connect_()
        {
            try
            {
                Database.EnsureCreated();   // Create database if no created
                Database.BeginTransaction(IsolationLevel.Serializable);
                return true;
            }
            catch (Exception p_exp_)
            {
                return false;
            }
        }

        public Boolean f_close(Boolean p_cmt_)
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
            catch (DbUpdateException p_exp_)
            {
                s_err_ = p_exp_.Message;
                return false;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;database=db_arbweb;Uid=root;Pwd=123456aA&");
        }

        protected override void OnModelCreating(ModelBuilder p_bld_)
        {
            p_bld_.Entity<_c_member>().HasIndex(p_ent_ => p_ent_.s_nam_).IsUnique();
        }

        // A table of members
        public virtual DbSet<_c_member> t_members { get; set; }

        // A table of game plays
        public virtual DbSet<_c_game> t_games { get; set; }
    }

    // Class represents a single member
    [Table("t_members")]
    public class _c_member
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }    // ID

        [Column("c_name")]
        [MinLength(3, ErrorMessage = "اسم الدخول يجب ألا يقل عن 3 أحرف"),
            MaxLength(30, ErrorMessage ="اسم الدخول يجب ألا يزيد عن 30 حرف")]
        public string s_nam_ { get; set; }  // Name

        [Column("c_password")]
        [MinLength(6, ErrorMessage = "كلمة المرور يجب ألا تقل عن 6 أحرف"),
            MaxLength(30, ErrorMessage = "كلمة المرور يجب ألا تزيد عن 30 حرف")]
        public string s_pas_ { get; set; }  // Password

        public _c_member(string p_nam_, string p_pas_)
        {
            s_nam_ = p_nam_;
            s_pas_ = p_pas_;
        }
    }

    // Class game data for each member
    [Table("t_gemes")]
    public partial class _c_game
    {
        [Key, Column("c_uid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long s_uid_ { get; set; }    // ID

        [Column("c_member")]
        public long s_mem_ { get; set; }    // Member ID

        [Column("c_board")]
        // Workaround: using int[] instead od byte[] so that it can be serialized to JSON properly
        public int[] s_brd_ { get; set; }   // Board configuration e.x: { 0, 1, 2, 0, 1, 2, 0, 1, 1 }
                                            // 0: Empty cell, 1: User, 2: Server

        [Column("c_wins")]
        public int s_win_ { get; set; }     // Score

        [Column("c_loses")]
        public int s_los_ { get; set; }     // How many loses

        // Not saved in database
        [NotMapped]
        public byte s_clk_ { get; set; }    // Index of cell clicked, 9 for just loading the game

        public _c_game()
        {
            s_brd_ = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}