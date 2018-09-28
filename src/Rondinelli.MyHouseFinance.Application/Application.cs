using Microsoft.Practices.ServiceLocation;
using Rondinelli.MyHouseFinance.Infra.Data.Interfaces;

namespace Rondinelli.MyHouseFinance.Application
{
    public class Application
    {
        private IUnitOfWork _uow;
        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChances();
        }
    }
}