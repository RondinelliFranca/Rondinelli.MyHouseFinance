using System;
using Microsoft.Practices.ServiceLocation;
using Rondinelli.MyHouseFinance.Infra.Data.Contexts;
using Rondinelli.MyHouseFinance.Infra.Data.Interfaces;

namespace Rondinelli.MyHouseFinance.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyHouseFinanceContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            _dbContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChances()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}