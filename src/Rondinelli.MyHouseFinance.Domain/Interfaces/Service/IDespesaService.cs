using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Domain.Interfaces.Service
{
    public interface IDespesaService : IDisposable
    {
        Despesa Adcionar(Despesa despesa);
        Despesa Atualizar(Despesa despesa);
        Despesa ObterPorId(Guid id);
        IEnumerable<Despesa> Buscar(Expression<Func<Despesa, bool>> predicate);
        IEnumerable<Despesa> ObterTodos();
        void Remover(Guid id);
    }
}