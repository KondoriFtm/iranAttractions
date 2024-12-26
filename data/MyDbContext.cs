using iranAttractions.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace iranAttractions.data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<Comment> Comment  { get; set; }

        public DbSet<Parts> Part  { get; set; }

        public DbSet<Picture> Pictures  { get; set; }

        public DbSet<Sightseeing> sightseeing  { get; set; }

        public DbSet<User> User  { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Phonenumber).ValueGeneratedNever(); // Ensure PhoneNumber is not auto-generated }

        }

    }
}
