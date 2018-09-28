using System;
using System.Collections.Generic;
using Rondinelli.MyHouseFinance.Application.ViewModels;

namespace Rondinelli.MyHouseFinance.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorId(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        void Deletar(Guid id);
    }
}