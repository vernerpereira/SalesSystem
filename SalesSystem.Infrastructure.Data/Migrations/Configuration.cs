using System.Data.Entity.Migrations;
using SalesSystem.Infrastructure.Data.Data;

namespace SalesSystem.Infrastructure.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            //CustomerSeed.Seed(context);
            //ProductSeed.Seed(context);
        }
    }
}
