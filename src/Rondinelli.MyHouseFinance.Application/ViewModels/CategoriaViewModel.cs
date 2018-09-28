using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Rondinelli.MyHouseFinance.Application.Interfaces;

namespace Rondinelli.MyHouseFinance.Application.ViewModels
{
    public class CategoriaViewModel
    {
        private static ICategoriaAppService _categoriaAppService;

        public CategoriaViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public static IEnumerable<CategoriaViewModel> ListarTodos()
        {
            _categoriaAppService = DependencyResolver.Current.GetService<ICategoriaAppService>();
            return _categoriaAppService.ObterTodos();
        }
    }
}