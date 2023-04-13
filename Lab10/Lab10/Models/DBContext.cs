using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Context : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> People { get; set; }

        public Context() : base("DBConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(e => e.ID);
            modelBuilder.Entity<Person>().HasKey(e => e.ID);
        }
    }
}
