using System.Data.Entity.ModelConfiguration;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Infrastructure.Data.Data.Config
{
    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .HasMaxLength(Product.NameMaxLength)
                .IsRequired();

            Property(p => p.Price)
                .HasPrecision(9, 2)
                .IsRequired();
        }
    }
}
