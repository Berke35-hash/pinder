﻿using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
//using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class PinderContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Server = mssql.sadikturan.com(orhanardaduman_); Database = orhanardaduman_; user = orhanardaduman; password = '_yd3Qn11'; ",
            //        builder => builder.EnableRetryOnFailure());
            //}

           optionsBuilder.UseMySql("Server = mssql.sadikturan.com; Database = orhanardaduman_; user = orhanardaduman; password = '_yd3Qn11'; ");
        }
    
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<PostImage> PostImage { get; set; }
        //"Server=93.89.238.98;Database=orhanardaduman_;user=orhanardaduman;password='_yd3Qn11';"
    }
}
