using System.Data.Entity.Migrations;
using Rondinelli.MyHouseFinance.Infra.Data.Contexts;

namespace Rondinelli.MyHouseFinance.Infra.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<MyHouseFinanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyHouseFinanceContext context)
        {
            //base.Seed(context);
        }
    }
}