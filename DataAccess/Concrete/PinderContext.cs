using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class PinderContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=93.89.238.98:8880;port=3306;Database=pinder;Uid=orhanardaduman;Pwd='_yd3Qn11';");
            //optionsBuilder.UseSqlServer();
        }
    
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
