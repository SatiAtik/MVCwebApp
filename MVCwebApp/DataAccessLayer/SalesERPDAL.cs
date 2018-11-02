using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCwebApp.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCwebApp.DataAccessLayer
{
    public class SalesERPDAL : DbContext
    {


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            //modelBuilder.Entity<UserDetails>().ToTable("TblUsers");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Employee> Employees { get; set; }        
        public DbSet<UserDetails> users { get; set; }
    }
}