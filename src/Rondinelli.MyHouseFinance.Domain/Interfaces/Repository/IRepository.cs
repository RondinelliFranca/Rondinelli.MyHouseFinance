﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Rondinelli.MyHouseFinance.Domain.Interfaces.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Adicionar(TEntity obj);
        TEntity ObterPorId(Guid id);
        IEnumerable<TEntity> ObterTodos();
        TEntity Atualizar(TEntity obj);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
        void Remover(Guid id);
    }
}