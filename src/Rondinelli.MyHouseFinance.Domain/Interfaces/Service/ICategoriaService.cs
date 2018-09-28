using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Domain.Interfaces.Service
{
    public interface ICategoriaService : IDisposable
    {
        Categoria Adcionar(Categoria categoria);
        Categoria Atualizar(Categoria categoria);
        Categoria ObterPorId(Guid id);
        IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicate);
        IEnumerable<Categoria> ObterTodos();
        void Remover(Guid id);
    }
}