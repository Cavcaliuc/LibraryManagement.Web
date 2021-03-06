﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibraryManagement.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Location Location { get; set; }

        public string DateOfBirth { get; set; }

        public byte[] Photo { get; set; }

        public byte[] PhotoThumbnail { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //Lookups
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        //Entities

        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasIndex(l => new { l.ParentLocationId, l.Name }).IsUnique(true);
            modelBuilder.Entity<Order>().HasMany(i => i.Messages)
                .WithRequired()
                .HasForeignKey(si => si.OrderId);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove();
        }
    }
}