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
        DbSet<Post> Posts { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<OperationClaim> OperationClaims { get; set; }
        DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
