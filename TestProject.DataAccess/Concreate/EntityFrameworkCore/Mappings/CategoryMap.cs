using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Entity.Concreate;

namespace TestProject.DataAccess.Concreate.EntityFrameworkCore.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"Categories", @"dbo");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.AddedBy).HasColumnName("AddedBy");
            builder.Property(d => d.AddedDate).HasColumnName("AddedDate");
            builder.Property(d => d.IsActive).HasColumnName("IsActive");
            builder.Property(d => d.Name).HasColumnName("Name");
           
        }
    }
}
