using Microsoft.EntityFrameworkCore;
using SinglePaymentAPI.Models;

namespace SinglePaymentAPI.Data;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<WalletEntity> Wallets { get; set; }

    public DbSet<TransferEntity> Transfers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<WalletEntity>()
        .HasIndex(w => new { w.SSNorEIN, w.Email })
        .IsUnique();

        modelBuilder.Entity<WalletEntity>()
            .Property(t => t.Balance)
            .HasColumnType("decimal(18,2");

        modelBuilder.Entity<WalletEntity>()
            .Property(w => w.UserType)
            .HasConversion<string>();

        modelBuilder.Entity<TransferEntity>()
            .HasKey(t => t.IdTransaction);

        modelBuilder.Entity<TransferEntity>()
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Transaction_Sender");


    }
}
