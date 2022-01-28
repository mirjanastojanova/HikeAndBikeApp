using HikeAndBike.Domain.Domain;
using HikeAndBike.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HikeAndBike.Repository
{
    public class ApplicationDbContext : IdentityDbContext<HikeAndBikeApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Trail> Trails { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TrailGuide> TrailGuides { get; set; }
        public virtual DbSet<TrailInShoppingCart> TrailInShoppingCarts { get; set; }
        public virtual DbSet<GuideForTrail> GuideForTrails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trail>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TrailGuide>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TrailInShoppingCart>()
                .HasKey(z => new { z.TrailId, z.ShoppingCartId });

            builder.Entity<GuideForTrail>()
                .HasKey(z => new { z.TrailId, z.TrailGuideId });

            builder.Entity<TrailInShoppingCart>()
                .HasOne(z => z.Trail)
                .WithMany(z => z.TrailInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<TrailInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.TrailInShoppingCarts)
                .HasForeignKey(z => z.TrailId);

            builder.Entity<GuideForTrail>()
                .HasOne(z => z.Trail)
                .WithMany(z => z.GuideForTrails)
                .HasForeignKey(z => z.TrailGuideId);

            builder.Entity<GuideForTrail>()
                .HasOne(z => z.TrailGuide)
                .WithMany(z => z.GuideForTrails)
                .HasForeignKey(z => z.TrailId);

            builder.Entity<ShoppingCart>()
                .HasOne<HikeAndBikeApplicationUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            builder.Entity<TrailInOrder>()
                .HasKey(z => new { z.TrailId, z.OrderId });

            builder.Entity<TrailInOrder>()
                .HasOne(z => z.SelectedTrail)
                .WithMany(z => z.Orders)
                .HasForeignKey(z => z.TrailId);

            builder.Entity<TrailInOrder>()
                .HasOne(z => z.UserOrder)
                .WithMany(z => z.TrailInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
