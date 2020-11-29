using Microsoft.EntityFrameworkCore;
using Models;
using SpeedrunAppBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data
{
    public class SpeedrunDbContext : DbContext
    {
        public SpeedrunDbContext(DbContextOptions<SpeedrunDbContext> options) : base(options)
        {

        }
        public DbSet<GameCategoryModerator> GameCategoryModerators { get; set; }
        public DbSet<PulseMessage> PulseMessages { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameCategoryModerator>(e =>
            {
                e.HasKey(m => new { m.GameId, m.CategoryId, m.UserId });
            });

            modelBuilder.Entity<PulseMessage>(e =>
            {
                e.HasKey(p => new { p.GameId, p.UserId, p.SendTime });
            });

            modelBuilder.Entity<UserSubscription>(e =>
            {
                e.HasKey(e => new { e.User1Id, e.User2Id });

                e.HasOne(e => e.User1)
                    .WithMany(e => e.SubscribtionsTo)
                    .HasForeignKey(e => e.User1Id);
                e.HasOne(e => e.User2)
                    .WithMany(e => e.SubscribtionsFrom)
                    .HasForeignKey(e => e.User2Id);
            });
        }
    }
}
