using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Repository;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Domain.Service
{
    public class DespesaService : IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DespesaService(IDespesaRepository despesaRepository, IUsuarioRepository usuarioRepository)
        {
            _despesaRepository = despesaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public DespesaService()
        {
            
        }
        public void Dispose()
        {
            _despesaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public Despesa Adcionar(Despesa despesa)
        {
            if (!despesa.Casal) return _despesaRepository.Adicionar(despesa);
            GerarDespesaCasal(despesa);
            return null;

        }

        private void GerarDespesaCasal(Despesa despesa)
        {

            var rondinelli = ObterRondinelliOuNathalia(true);
            var nathy = ObterRondinelliOuNathalia(false);

            var despesa01 = new Despesa
            {
                Casal = true,
                DataCompra = despesa.DataCompra,
                Descricao = despesa.Descricao,
                Id = Guid.NewGuid(),
                MesReferencia = despesa.MesReferencia,
                Parcelas = despesa.Parcelas,
                ResponsavelPagadorId = rondinelli.Id,
                ResponsavelPagador = rondinelli,
                TipoPagamento = despesa.TipoPagamento,
                Valor = despesa.Valor / 2, 
                CategoriaId = despesa.CategoriaId
            };

            var despesa02 = new Despesa
            {
                Casal = true,
                DataCompra = despesa.DataCompra,
                Descricao = despesa.Descricao,
                Id = Guid.NewGuid(),
                MesReferencia = despesa.MesReferencia,
                Parcelas = despesa.Parcelas,
                ResponsavelPagadorId = nathy.Id,
                ResponsavelPagador = nathy,
                TipoPagamento = despesa.TipoPagamento,
                Valor = despesa.Valor / 2,
                CategoriaId = despesa.CategoriaId
            };
            _despesaRepository.Adicionar(despesa01);
            _despesaRepository.Adicionar(despesa02);
        }



        public Despesa Atualizar(Despesa despesa)
        {
            return _despesaRepository.Atualizar(despesa);
        }

        public Despesa ObterPorId(Guid id)
        {
            return _despesaRepository.ObterPorId(id);
        }

        public IEnumerable<Despesa> Buscar(Expression<Func<Despesa, bool>> predicate)
        {
            return _despesaRepository.Buscar(predicate);
        }

        public IEnumerable<Despesa> ObterTodos()
        {
            return _despesaRepository.ObterTodos().ToList();
        }

        public void Remover(Guid id)
        {
            _despesaRepository.Remover(id);
        }

        public bool ValidarDespesa(Despesa despesa)
        {
            if (despesa.Id == null)
            {
                return false;
            }

            if (despesa.Descricao == null)
            {
                return false;
            }

            if (despesa.Categoria == null)
            {
                return false;
            }

            if (despesa.MesReferencia == null)
            {
                return false;
            }

            if (despesa.TipoPagamento == null)
            {
                return false;
            }

            return true;
        }

        public Usuario ObterRondinelliOuNathalia(bool rond)
        {
            return rond ? _usuarioRepository.Buscar(x => x.Nome == "Rondinelli").FirstOrDefault() : _usuarioRepository.Buscar(x => x.Nome == "Nathalia").FirstOrDefault();
        }
    }
}