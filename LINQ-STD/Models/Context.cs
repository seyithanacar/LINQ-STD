using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace LINQ_STD.Models
{
    public class Context : DbContext
    {
        public DbSet<Student>Students { get; set; }
        public DbSet<Note>Notes { get; set; }
        public DbSet<Lesson>Lessons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}