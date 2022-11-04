﻿using Microsoft.EntityFrameworkCore;
using Muresan_Cristian_Lab2.Models;

namespace Muresan_Cristian_Lab2.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<Book> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}