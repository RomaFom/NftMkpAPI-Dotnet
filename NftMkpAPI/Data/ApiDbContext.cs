using Microsoft.EntityFrameworkCore;
using NftMkpAPI.Models;

namespace NftMkpAPI.Data;

public class ApiDbContext : DbContext
{
    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Nft> Nfts { get; set; }
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Nft>().ToTable("nfts");
        modelBuilder.Entity<Nft>().Property(n => n.Nft_Id).HasColumnName("nft_id");
        modelBuilder.Entity<Nft>().Property(n => n.Owner).HasColumnName("owner");
        modelBuilder.Entity<Nft>().Property(n => n.Image).HasColumnName("image");
        modelBuilder.Entity<Nft>().Property(n => n.Description).HasColumnName("description");
        modelBuilder.Entity<Nft>().Property(n => n.Id).HasColumnName("id");
        modelBuilder.Entity<Nft>().Property(n => n.Name).HasColumnName("name");

        modelBuilder.Entity<Item>().ToTable("items");
        modelBuilder.Entity<Item>().Property(i => i.Id).HasColumnName("id");
        modelBuilder.Entity<Item>().Property(i => i.Item_Id).HasColumnName("item_id");
        modelBuilder.Entity<Item>().Property(i => i.Nft_Id).HasColumnName("nft_id");
        modelBuilder.Entity<Item>().Property(i => i.Price).HasColumnName("price");
        modelBuilder.Entity<Item>().Property(i => i.Listing_Price).HasColumnName("listing_price");
        modelBuilder.Entity<Item>().Property(i => i.Seller).HasColumnName("seller");
        modelBuilder.Entity<Item>().Property(i => i.Total_Price).HasColumnName("total_price");
        modelBuilder.Entity<Item>().Property(i => i.Is_Sold).HasColumnName("is_sold");

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasOne(i => i.Nft)
            .WithOne(nft => nft.Item)
            .HasForeignKey<Item>(i => i.Nft_Id).HasPrincipalKey<Nft>(nft => nft.Nft_Id);
        });
    }

}
