using System.Data.Entity.ModelConfiguration;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Infrastructure.Data.Data.Config
{
    public class SaleConfigurations : EntityTypeConfiguration<Sale>
    {
        public SaleConfigurations()
        {
            HasKey(s => s.Id);

            Property(s => s.OrderNumber)
                .HasMaxLength(Sale.OrderNumberMaxLength)
                .IsRequired();

            HasRequired(s => s.Customer)
                .WithMany(s => s.Sales)
                .HasForeignKey(s => s.CustomerId);
        }
    }
}
