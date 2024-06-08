using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.DataAccess.Concreate.EntityFrameworkCore.Mappings;
using TestProject.Entity.Concreate;

namespace TestProject.DataAccess.Concreate.EntityFrameworkCore
{
    public class TestProjectDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-J3JN1T3;Database=TestProject;Integrated Security=true;Connection Timeout=1800;MultipleActiveResultSets=True");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());
        }
    }
}
