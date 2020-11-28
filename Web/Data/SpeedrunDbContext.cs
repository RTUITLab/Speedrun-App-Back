using Microsoft.EntityFrameworkCore;
using Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<GameCategoryModerator>(e =>
            {
                e.HasKey(m => new { m.GameId, m.CategoryId, m.UserId });
            });
        }
    }
}
