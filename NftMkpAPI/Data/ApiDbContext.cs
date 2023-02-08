using Microsoft.EntityFrameworkCore;
using NftMkpAPI.Models;

namespace NftMkpAPI.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Nft> Nfts { get; set; }
    public virtual  DbSet<User> Users { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Nft>().ToTable("nfts");
        modelBuilder.Entity<Item>().ToTable("items");
        modelBuilder.Entity<Transaction>().ToTable("transactions");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasOne(i => i.Nft)
            .WithOne(nft => nft.Item)
            .HasForeignKey<Item>(i => i.Nft_Id).HasPrincipalKey<Nft>(nft => nft.Nft_Id);
        });

        
    }
}
