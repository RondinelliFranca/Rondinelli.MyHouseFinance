using System;
using System.Collections.Generic;
using AutoMapper;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Application.AppService
{
    public class UsuarioAppService: Application, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioViewModel Adicionar(UsuarioViewModel usuarioViewModel)
        {
            BeginTransaction();

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            var usuarioBd = _usuarioService.Adcionar(usuario);

            Commit();

            return Mapper.Map<Usuario, UsuarioViewModel>(usuarioBd);
        }

        public UsuarioViewModel Atualizar(UsuarioViewModel usuarioViewModel)
        {
            BeginTransaction();

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            var usuarioBd = _usuarioService.Atualizar(usuario);

            Commit();

            return Mapper.Map<Usuario, UsuarioViewModel>(usuarioBd);
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.ObterPorId(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.ObterTodos());
        }

        public void Deletar(Guid id)
        {
            BeginTransaction();

            _usuarioService.Remover(id);

            Commit();
        }
    }
}