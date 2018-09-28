using Rondinelli.MyHouseFinance.Application.ViewModels.Relatorios;

namespace Rondinelli.MyHouseFinance.Application.Interfaces
{
    public interface IRelatorioAppService
    {
        RelatorioDespesasViewModel GerarGraficoPorDespesas(string mesReferencia);
        RelatorioDespesasViewModel GerarGraficoPagamento(string mesReferencia, string usuarioId);
    }
}