namespace Rondinelli.MyHouseFinance.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void SaveChances();
    }
}