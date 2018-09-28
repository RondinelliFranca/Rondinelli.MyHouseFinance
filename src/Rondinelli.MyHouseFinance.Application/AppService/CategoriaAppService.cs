using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Application.AppService
{
    public class CategoriaAppService : Application, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public void Dispose()
        {
            _categoriaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public CategoriaViewModel Adicionar(CategoriaViewModel categoriaViewModel)
        {
            BeginTransaction();

            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            var categoriaBd = _categoriaService.Adcionar(categoria);

            Commit();

            return Mapper.Map<Categoria, CategoriaViewModel>(categoriaBd);
        }

        public CategoriaViewModel Atualizar(CategoriaViewModel categoriaViewModel)
        {
            BeginTransaction();

            var categoria = Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel);
            var categoriaBd = _categoriaService.Atualizar(categoria);

            Commit();

            return Mapper.Map<Categoria, CategoriaViewModel>(categoriaBd);
        }

        public CategoriaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_categoriaService.ObterPorId(id));
        }

        public IEnumerable<CategoriaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaService.ObterTodos().OrderBy(x=>x.Nome));
        }

        public IEnumerable<CategoriaViewModel> Buscar(Expression<Func<CategoriaViewModel, bool>> predicate)
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaService.Buscar(x=>x.Nome == predicate.Name));
        }

        public void Deletar(Guid id)
        {
            BeginTransaction();

            _categoriaService.Remover(id);

            Commit();
        }
    }
}