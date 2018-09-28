using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Repository;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Domain.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository; 

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario Adcionar(Usuario usuario)
        {
            return _usuarioRepository.Adicionar(usuario);
        }

        public Usuario ObterPorId(Guid id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioRepository.ObterTodos();
        }

       public Usuario Atualizar(Usuario usuario)
        {
            return _usuarioRepository.Atualizar(usuario);
        }

        public IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            _usuarioRepository.Remover(id);
        }

        
    }
}