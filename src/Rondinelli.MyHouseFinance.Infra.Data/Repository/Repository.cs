using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Repository;
using Rondinelli.MyHouseFinance.Infra.Data.Contexts;
using Rondinelli.MyHouseFinance.Infra.Data.Interfaces;

namespace Rondinelli.MyHouseFinance.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected MyHouseFinanceContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            Db = contextManager.GetContext();
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Adicionar(TEntity obj)
        {
            obj = DbSet.Add(obj);
            return obj;
        }

        public TEntity ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return DbSet.ToList();
        }

        public TEntity Atualizar(TEntity obj)
        {
            Db.Set<TEntity>().AddOrUpdate(obj);
            return obj;
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(ObterPorId(id));
        }
    }
}