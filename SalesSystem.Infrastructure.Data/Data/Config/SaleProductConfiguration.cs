using System.Data.Entity.ModelConfiguration;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Infrastructure.Data.Data.Config
{
    public class SaleProductConfiguration : EntityTypeConfiguration<SaleProduct>
    {
        public SaleProductConfiguration()
        {
            HasKey(s => s.Id);

            Property(s => s.Quantity)
                .IsRequired();

            Property(s => s.UnitPrice)
                .HasPrecision(9,2)
                .IsRequired();

            HasRequired(s => s.Product)
                .WithMany(s => s.SaleProducts)
                .HasForeignKey(s => s.ProductId);

            HasRequired(s => s.Sale)
                .WithMany(s => s.SaleProducts)
                .HasForeignKey(s => s.SaleId);
        }
    }
}
