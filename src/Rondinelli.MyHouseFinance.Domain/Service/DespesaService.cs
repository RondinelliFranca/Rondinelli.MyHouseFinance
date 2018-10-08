using System;
using System.Collections.Generic;
using System.Globalization;
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
            try
            {
                if (despesa.Parcelas != 0)
                {
                    ProcessarDespesas(despesa);
                    return new Despesa();
                }

                if (!despesa.Casal) return _despesaRepository.Adicionar(despesa);
                GerarDespesaCasal(despesa);
                return new Despesa();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private Despesa GerarDespesasParceladas(Despesa despesa, int parcela)
        {
            var dataMesReferencia = DateTime.Parse(despesa.MesReferencia.ToString(), new CultureInfo("pt-BR"));
            var dataMesSeguinte = dataMesReferencia.AddMonths(parcela);
            var dataReferencia = dataMesSeguinte.Month.ToString() + "/" + dataMesSeguinte.Year.ToString();


            var despesaGerada = new Despesa()
            {
                Id = Guid.NewGuid(),
                Descricao = despesa.Descricao,
                MesReferencia = dataReferencia,
                Valor = despesa.Valor,
                DataCompra = despesa.DataCompra,
                Parcelas = despesa.Parcelas - parcela,
                TipoPagamento = despesa.TipoPagamento,
                Casal = despesa.Casal,
                ResponsavelPagador = despesa.ResponsavelPagador,
                ResponsavelPagadorId = despesa.ResponsavelPagadorId,
                Categoria = despesa.Categoria,
                CategoriaId = despesa.CategoriaId,
                DividirDespesa = despesa.DividirDespesa,
                Ids = despesa.Ids
            };

            return despesaGerada;

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

        public Despesa Atualizar(Despesa despesa)
        {
            return _despesaRepository.Atualizar(despesa);
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

        #region Private 

        private void ProcessarDespesas(Despesa despesa)
        {
            for (var i = 0; i < despesa.Parcelas; i++)
            {
                var despesaParcela = GerarDespesasParceladas(despesa, i);
                if (!despesaParcela.Casal)
                {
                    if (despesaParcela.DividirDespesa)
                    {
                        DividirDespesas(despesaParcela);
                    }
                    else
                    {
                        _despesaRepository.Adicionar(despesaParcela);
                    }
                }
                else
                {
                    GerarDespesaCasal(despesaParcela);
                }
            }
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
                CategoriaId = despesa.CategoriaId,
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

        private void DividirDespesas(Despesa despesa)
        {
            foreach (var t in despesa.Ids)
            {
                var usuario = _usuarioRepository.ObterPorId(Guid.Parse(t));
                var desespaDividia = new Despesa()
                {
                    Casal = despesa.Casal,
                    DataCompra = despesa.DataCompra,
                    Descricao = despesa.Descricao,
                    Id = Guid.NewGuid(),
                    MesReferencia = despesa.MesReferencia,
                    Parcelas = despesa.Parcelas,
                    ResponsavelPagadorId = usuario.Id,
                    ResponsavelPagador = usuario,
                    TipoPagamento = despesa.TipoPagamento,
                    Valor = despesa.Valor / despesa.Ids.Count,
                    CategoriaId = despesa.CategoriaId,
                };

                _despesaRepository.Adicionar(desespaDividia);
            }
        }

        #endregion
    }
}