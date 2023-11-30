using Microsoft.EntityFrameworkCore;
using MyExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenseTracker.Repository.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Bank> Banks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>().HasData(new Bank()
            {
                Id = 1,
                Name = "State Bank of India",
                Acrynonym = "SBI",
                Type = "National"
            },
            new Bank()
            {
                Id = 2,
                Name = "HDFC Bank",
                Acrynonym = "HDFC",
                Type = "National"
            },
            new Bank()
            {
                Id = 3,
                Name = "ICICI Bank",
                Acrynonym = "ICICI",
                Type = "National"
            },
            new Bank()
            {
                Id = 4,
                Name = "Axis Bank",
                Acrynonym = "AXIS",
                Type = "National"
            },
            new Bank()
            {
                Id = 5,
                Name = "Bank of Baroda",
                Acrynonym = "BOB",
                Type = "National"
            },
            new Bank()
            {
                Id = 6,
                Name = "Bank of India",
                Acrynonym = "BOI",
                Type = "National"
            },
            new Bank()
            {
                Id = 7,
                Name = "Central Bank of India",
                Acrynonym = "CBI",
                Type = "National"
            },
            new Bank()
            {
                Id = 8,
                Name = "Punjab National Bank",
                Acrynonym = "PNB",
                Type = "National"
            },
            new Bank()
            {
                Id = 9,
                Name = "Union Bank of India",
                Acrynonym = "UBI",
                Type = "National"
            },
            new Bank()
            {
                Id = 10,
                Name = "Kotak Mahindra Bank Ltd.",
                Acrynonym = "KOTAK",
                Type = "National"
            });
        }
    }
}
