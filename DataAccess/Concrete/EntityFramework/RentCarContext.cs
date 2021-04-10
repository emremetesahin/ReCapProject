using Core.Entities;
using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentCarContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentCar;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CreditCard>CreditCards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        //public DbSet<Marka> Markalar { get; set; }


        //Veritabanındaki tablo adlarından farklı bir propety oluşturmak istersek eğer aşağıdaki gibi override edeiz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasDefaultSchema("dbo"); --tablo adı başındaki yetkilendirmeyi ayarlar dbo/admin vs

            // modelBuilder.Entity<Markalar>().ToTable("Brands"); Markalar sınıfı Brands tablosuna karşılık geliyor

            // modelBuilder.Entity<Markalar>().Property(p => p.Id).HasColumnName("BrandId");
            // Markalar sınıfındaki Id özelliği ilgili sınıftaki(Brands) tablosundaki BrandId ye eşit

            // modelBuilder.Entity<Markalar>().Property(p => p.MarkaAdi).HasColumnName("BrandName");
            // Markalar sınıfındaki MarkaAdi özelliği ilgili sınıftaki(Brands) tablosundaki BrandName e eşit

        }
    }
    }
