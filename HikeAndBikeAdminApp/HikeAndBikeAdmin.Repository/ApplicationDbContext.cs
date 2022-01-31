using HikeAndBikeAdmin.Domain.Domain;
using HikeAndBikeAdmin.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HikeAndBikeAdmin.Repository
{
    public class ApplicationDbContext : IdentityDbContext<HikeAndBikeUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Trail> Trails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trail>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
