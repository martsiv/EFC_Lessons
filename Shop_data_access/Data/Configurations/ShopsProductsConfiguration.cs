using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_data_access.Entities;

namespace Shop_data_access.Data.Configurations
{
    public class ShopsProductsConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasMany(s => s.Products)
                 .WithMany(p => p.Shops)
                 .UsingEntity<ShopsProducts>(
                     j => j
                         .HasOne(o => o.Product)
                         .WithMany(m => m.ShopsProducts)
                         .HasForeignKey(k => k.ProductId),
                     j => j
                         .HasOne(o => o.Shop)
                         .WithMany(m => m.ShopsProducts)
                         .HasForeignKey(k => k.ShopId),
                     j =>
                     {
                         j.HasKey(key => new { key.ShopId, key.ProductId });
                         j.ToTable("ShopsProducts");
                         j.HasData(new ShopsProducts[]
                         {
                            new ShopsProducts(){ ShopId=1, ProductId=1 },
                            new ShopsProducts(){ ShopId=1, ProductId=2 },
                            new ShopsProducts(){ ShopId=1, ProductId=3 },
                            new ShopsProducts(){ ShopId=1, ProductId=4 },
                            new ShopsProducts(){ ShopId=1, ProductId=5 },
                            new ShopsProducts(){ ShopId=2, ProductId=1 },
                            new ShopsProducts(){ ShopId=2, ProductId=2 },
                            new ShopsProducts(){ ShopId=2, ProductId=3 },
                            new ShopsProducts(){ ShopId=2, ProductId=4 },
                            new ShopsProducts(){ ShopId=2, ProductId=5 },
                            new ShopsProducts(){ ShopId=3, ProductId=1 },
                            new ShopsProducts(){ ShopId=3, ProductId=2 },
                            new ShopsProducts(){ ShopId=3, ProductId=3 },
                            new ShopsProducts(){ ShopId=3, ProductId=4 },
                            new ShopsProducts(){ ShopId=3, ProductId=5 },
                            new ShopsProducts(){ ShopId=4, ProductId=1 },
                            new ShopsProducts(){ ShopId=4, ProductId=2 },
                            new ShopsProducts(){ ShopId=4, ProductId=3 },
                            new ShopsProducts(){ ShopId=4, ProductId=4 },
                            new ShopsProducts(){ ShopId=4, ProductId=5 },
                            new ShopsProducts(){ ShopId=5, ProductId=1 },
                            new ShopsProducts(){ ShopId=5, ProductId=2 },
                            new ShopsProducts(){ ShopId=5, ProductId=3 },
                            new ShopsProducts(){ ShopId=5, ProductId=4 },
                            new ShopsProducts(){ ShopId=5, ProductId=5 },
                            new ShopsProducts(){ ShopId=6, ProductId=1 },
                            new ShopsProducts(){ ShopId=6, ProductId=2 },
                            new ShopsProducts(){ ShopId=6, ProductId=3 },
                            new ShopsProducts(){ ShopId=6, ProductId=4 },
                            new ShopsProducts(){ ShopId=6, ProductId=5 },
                         });
                     });
        }
    }
}