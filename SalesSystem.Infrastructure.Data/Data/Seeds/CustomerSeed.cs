using System;
using System.Data.Entity.Migrations;
using SalesSystem.Domain.Entities;
using SalesSystem.Domain.ValueObjects;

namespace SalesSystem.Infrastructure.Data.Data.Seeds
{
    public class CustomerSeed
    {
        public static void Seed(DataContext context)
        {
            context.Customers.AddOrUpdate(x=>x.Id, 
                new Customer("José da Silva", new DateTime(1992, 3, 22), new Phone("35", "3623-5544"), new Cpf("58567989612"), new Email("jose.silva@gmail.com")),
                new Customer("João Roberto Souza", new DateTime(1982, 12, 1), new Phone("35", "98877-4433"), new Cpf("83763777792"), new Email("joao.souza@live.com")),
                new Customer("Carlos Pereira", new DateTime(1988, 4, 6), new Phone("35", "3322-8790"), new Cpf("93416759010"), new Email("carlos.pereira@uol.com")),
                new Customer("Humberto Ferreira", new DateTime(2000, 9, 14), new Phone("35", "3422-9087"), new Cpf("41626525544"), new Email("humberto.ferreira@gmail.com"))
                );
        }
    }
}
