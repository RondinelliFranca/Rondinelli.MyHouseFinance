using System;
using System.Collections;
using System.Collections.Generic;
using Rondinelli.MyHouseFinance.Application.ViewModels;

namespace Rondinelli.MyHouseFinance.Application.Interfaces
{
    public interface IDespesaAppService : IDisposable
    {
        DespesaViewModel Adicionar(DespesaViewModel despesaViewModel);
        DespesaViewModel Atualizar(DespesaViewModel despesaViewModel);
        DespesaViewModel ObterPorId(Guid id);
        IEnumerable<DespesaViewModel> ObterTodos();
        IEnumerable<DespesaViewModel> ObterDespesaPorMesDeReferencia(string mes);
        IEnumerable<DespesaViewModel> ObterDespesaPorCategoria(CategoriaViewModel categoria);
        IEnumerable<DespesaViewModel> ObterDespesaPorResponsavel(UsuarioViewModel usuario);
        void Deletar(Guid id);
    }
}