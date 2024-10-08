﻿using Microsoft.EntityFrameworkCore;
using Store1.Services.CouponAPI.Models;

namespace Store1.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> coupons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "100FF",
                DiscountAmount = 10,
                MinAmount = 20,
            });


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "200FF",
                DiscountAmount = 20,
                MinAmount = 40,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "300FF",
                DiscountAmount = 50,
                MinAmount = 40,
            });
        }
    }
}
