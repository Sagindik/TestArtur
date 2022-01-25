﻿using Microsoft.EntityFrameworkCore;


namespace TestArtur.Data
{
    public class NovostiContext : DbContext
    {
        
        public NovostiContext(DbContextOptions<NovostiContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categorys { get; set; }
        public DbSet<Teg> Tegs { get; set; }
        public DbSet<Novost> Novosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Teg>().ToTable("Teg");
            modelBuilder.Entity<Novost>().ToTable("Novost");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //  => options.UseSqlite(@"Data Source=D:\TestArtur\bdsqlite.db");

    }
}
 