using Rondinelli.MyHouseFinance.Infra.Data.Contexts;

namespace Rondinelli.MyHouseFinance.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        MyHouseFinanceContext GetContext();
    }
}