using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc.Html;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Application.ViewModels.Relatorios;

namespace Rondinelli.MyHouseFinance.Application.AppService
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly ICategoriaAppService _categoriaAppService;
        private readonly IDespesaAppService _despesaAppService;
        private readonly IUsuarioAppService _usuarioAppService;
        public RelatorioAppService(ICategoriaAppService categoriaAppService, IDespesaAppService despesaAppService, IUsuarioAppService usuarioAppService)
        {
            _categoriaAppService = categoriaAppService;
            _despesaAppService = despesaAppService;
            _usuarioAppService = usuarioAppService;
        }

        public RelatorioDespesasViewModel GerarGraficoPorDespesas(string mesReferencia)
        {

            var listaDespesa = !string.IsNullOrWhiteSpace(mesReferencia) ? _despesaAppService.ObterDespesaPorMesDeReferencia(mesReferencia) : _despesaAppService.ObterTodos();
            var listaCategoria = _categoriaAppService.ObterTodos();

            var relatorio = new RelatorioDespesasViewModel
            {
                Labels = new List<string>(),
                Valor = new List<decimal>()
            };


            foreach (var categoriaViewModel in listaCategoria)
            {
                relatorio.Labels.Add(categoriaViewModel.Nome);
                var soma = listaDespesa.Where(despesa => despesa.Categoria.Id == categoriaViewModel.Id)
                                       .Sum(despesa => despesa.Valor);
                relatorio.Valor.Add(soma);
            }
            return relatorio;
        }

        public RelatorioDespesasViewModel GerarGraficoPagamento(string mesReferencia, string usuarioId)
        {
            var listaDespesa = !string.IsNullOrWhiteSpace(mesReferencia) ? _despesaAppService.ObterDespesaPorMesDeReferencia(mesReferencia) : _despesaAppService.ObterTodos();
            
            var listaUsuario = _usuarioAppService.ObterTodos();            

            var relatorio = new RelatorioDespesasViewModel
            {
                Labels = new List<string>(),
                Valor = new List<decimal>()
            };

            foreach (var usuario in listaUsuario)
            {
                relatorio.Labels.Add(usuario.Nome);
                var soma = listaDespesa.Where(despesa => despesa.ResponsavelPagadorId == usuario.Id)
                                       .Sum(despesa => despesa.Valor);

                relatorio.Valor.Add(soma);
            }

            return relatorio;
        }

        public RelatorioDespesasViewModel GraficoDoResponsavel(string mesReferencia, string usuarioId)
        {
            var listaDespesa = !string.IsNullOrWhiteSpace(mesReferencia) ? _despesaAppService.ObterDespesaPorMesDeReferencia(mesReferencia) : _despesaAppService.ObterTodos();
            var relatorio = new RelatorioDespesasViewModel
            {
                Labels = new List<string>(),
                Valor = new List<decimal>()
            };
            listaDespesa = listaDespesa.Where(x => x.ResponsavelPagadorId == Guid.Parse(usuarioId));

            foreach (var despesaViewModel in listaDespesa)
            {
                relatorio.Labels.Add(despesaViewModel.Descricao);
                relatorio.Valor.Add(despesaViewModel.Valor);
            }

            return relatorio;
        }
    }

}