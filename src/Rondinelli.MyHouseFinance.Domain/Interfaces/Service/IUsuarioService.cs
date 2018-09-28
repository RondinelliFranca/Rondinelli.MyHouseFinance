using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Domain.Interfaces.Service
{
    public interface IUsuarioService : IDisposable
    {
        Usuario Adcionar(Usuario usuario);
        Usuario ObterPorId(Guid id);
        IEnumerable<Usuario> ObterTodos();
        Usuario Atualizar(Usuario usuario);
        IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate);
        void Remover(Guid id);
    }
}