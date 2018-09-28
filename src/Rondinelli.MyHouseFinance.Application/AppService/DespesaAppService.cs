using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;

namespace Rondinelli.MyHouseFinance.Application.AppService
{
    public class DespesaAppService : Application, IDespesaAppService
    {
        private readonly IDespesaService _despesaService;

        public DespesaAppService(IDespesaService despesaService)
        {
            _despesaService = despesaService;
        }


        public void Dispose()
        {
            _despesaService.Dispose();
            GC.SuppressFinalize(this);
        }

        public DespesaViewModel Adicionar(DespesaViewModel despesaViewModel)
        {
            BeginTransaction();

            var despesa = Mapper.Map<DespesaViewModel, Despesa>(despesaViewModel);
            var despesaBd = _despesaService.Adcionar(despesa);

            Commit();

            return Mapper.Map<Despesa, DespesaViewModel>(despesaBd);
        }

        public DespesaViewModel Atualizar(DespesaViewModel despesaViewModel)
        {
            BeginTransaction();

            var despesa = Mapper.Map<DespesaViewModel, Despesa>(despesaViewModel);
            var despesaBd = _despesaService.Atualizar(despesa);

            Commit();

            return Mapper.Map<Despesa, DespesaViewModel>(despesaBd);
        }

        public DespesaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<Despesa, DespesaViewModel>(_despesaService.ObterPorId(id));
        }

        public IEnumerable<DespesaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaService.ObterTodos().OrderBy(x=>x.DataCompra));
        }

        public IEnumerable<DespesaViewModel> ObterDespesaPorMesDeReferencia(string mes)
        {
            return Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaService.ObterTodos().Where(x => x.MesReferencia == mes));
        }

        public IEnumerable<DespesaViewModel> ObterDespesaPorCategoria(CategoriaViewModel categoria)
        {
            return Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaService.ObterTodos().Where(x => x.Categoria.Id == categoria.Id));
        }

        public IEnumerable<DespesaViewModel> ObterDespesaPorResponsavel(UsuarioViewModel usuario)
        {
            return Mapper.Map<IEnumerable<Despesa>, IEnumerable<DespesaViewModel>>(_despesaService.ObterTodos().Where(x => x.ResponsavelPagador.Id == usuario.Id));
        }

        public void Deletar(Guid id)
        {
            BeginTransaction();

            _despesaService.Remover(id);

            Commit();
        }
    }
}