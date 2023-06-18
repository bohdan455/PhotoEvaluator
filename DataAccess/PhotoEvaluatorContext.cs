using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess
{
    public class PhotoEvaluatorContext : DbContext
    {
        public PhotoEvaluatorContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.EnsureHavingChatStates();
            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.Id, r.TelegramUserId })
                .IsUnique();
            modelBuilder.Entity<TelegramUser>()
                .Property(et => et.TelegramId)
                .ValueGeneratedNever();
        }
    }
}
