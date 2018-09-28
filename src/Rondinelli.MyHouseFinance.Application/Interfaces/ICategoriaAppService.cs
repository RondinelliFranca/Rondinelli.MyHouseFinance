using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Application.ViewModels;

namespace Rondinelli.MyHouseFinance.Application.Interfaces
{
    public interface ICategoriaAppService : IDisposable
    {
        CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel Atualizar(CategoriaViewModel categoriaViewModel);
        CategoriaViewModel ObterPorId(Guid id);
        IEnumerable<CategoriaViewModel> ObterTodos();
        IEnumerable<CategoriaViewModel> Buscar(Expression<Func<CategoriaViewModel, bool>> predicate);        
        void Deletar(Guid id);
    }
}