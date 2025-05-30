using Microsoft.EntityFrameworkCore;

namespace BancoCem.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Models.WalletEntity> Wallets { get; set; }
        public DbSet<Models.TransferenceEntity> Transferences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.WalletEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CPFCNPJ).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => new { e.CPFCNPJ, e.Email }).IsUnique();
                entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
                entity.Property(e => e.AccountBalance).HasColumnType("decimal(18,2)");
                entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime(0)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<Models.TransferenceEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.TransferDate)
                .HasColumnType("datetime(0)")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(e => e.Sender)
                      .WithMany()
                      .HasForeignKey(e => e.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Recipient)
                      .WithMany()
                      .HasForeignKey(e => e.RecipientId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Models.WalletEntity>().ToTable("Wallets");
            modelBuilder.Entity<Models.TransferenceEntity>().ToTable("Transferences");


        }
    }
}
