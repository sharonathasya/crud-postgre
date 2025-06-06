using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;

namespace crud.Data.Models
{
    public class dbContext(DbContextOptions<dbContext> options) : DbContext(options)
    {

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Product> Product { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Customer>()
                .Property(o => o.customerAddress)
                .HasDefaultValueSql("''");

            
        }
    }

}
