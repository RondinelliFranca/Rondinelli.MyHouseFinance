using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Repository;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Domain.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Dispose()
        {
            _categoriaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Categoria Adcionar(Categoria categoria)
        {
            return _categoriaRepository.Adicionar(categoria);
        }

        public Categoria Atualizar(Categoria categoria)
        {
            return _categoriaRepository.Atualizar(categoria);
        }

        public Categoria ObterPorId(Guid id)
        {
            return  _categoriaRepository.ObterPorId(id);
        }

        public IEnumerable<Categoria> Buscar(Expression<Func<Categoria, bool>> predicate)
        {
            return _categoriaRepository.Buscar(predicate);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _categoriaRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _categoriaRepository.Remover(id);
        }
    }
}