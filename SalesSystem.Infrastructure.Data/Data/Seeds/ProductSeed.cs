using System.Data.Entity.Migrations;
using SalesSystem.Domain.Entities;

namespace SalesSystem.Infrastructure.Data.Data.Seeds
{
    public class ProductSeed
    {
        public static void Seed(DataContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product("iPhone X 256Gb prata", new decimal(6534.45)),
                new Product("iPhone X 256Gb preto mate", new decimal(6534.45)),
                new Product("iPhone X 256Gb rosa", new decimal(6534.45)),
                new Product("iPhone X 128Gb branco", new decimal(5780.33)),
                new Product("iPhone X 128Gb dourado", new decimal(5780.33)),
                new Product("iPhone X 128Gb prata", new decimal(5780.33)),
                new Product("Bumper iPhone X preto", new decimal(122.30)),
                new Product("Bumper iPhone X rosa", new decimal(122.30)),
                new Product("Carregador iPhone X", new decimal(93.13)),
                new Product("Fone de ouvido", new decimal(322.78))
            );
        }
    }
}
