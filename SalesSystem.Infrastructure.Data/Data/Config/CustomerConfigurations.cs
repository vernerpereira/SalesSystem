using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Infrastructure.Data.Data.Config
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(c => c.Id);

            Property(c => c.BornDate)
                .IsRequired();

            Property(c => c.Name)
                .HasMaxLength(Customer.NameMaxLength)
                .IsRequired();

            Property(c => c.Email.Address)
                .HasColumnName("Email")
                .HasMaxLength(Email.AddressMaxLength)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) {IsUnique = true}))
                .IsRequired();

            Property(c => c.Cpf.Code)
                .HasColumnName("Cpf")
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_CPF", 2) { IsUnique = true }))
                .IsRequired();

            Property(c => c.Phone.Ddd)
                .HasColumnName("Ddd")
                .HasMaxLength(Phone.DddMaxLength)
                .IsRequired();

            Property(c => c.Phone.Number)
                .HasColumnName("Phone")
                .HasMaxLength(Phone.NumberMaxLength)
                .IsRequired();
            
        }
    }
}
