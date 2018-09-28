using System;
using System.Collections;
using System.Collections.Generic;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using System.Web.Mvc;

namespace Rondinelli.MyHouseFinance.Application.ViewModels
{
    public class UsuarioViewModel
    {
        private static IUsuarioAppService _usuarioAppService;

        public UsuarioViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CategoriaPessoa { get; set; }
       public virtual ICollection<DespesaViewModel> ListaDespesa { get; set; }
        public static IEnumerable<UsuarioViewModel> ListarTodos()
        {
            _usuarioAppService = DependencyResolver.Current.GetService<IUsuarioAppService>();
            return _usuarioAppService.ObterTodos();
        }
    }
}