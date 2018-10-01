using System;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;
using Rondinelli.MyHouseFinance.Domain.Service;

namespace Rondinelli.MyHouseFinance.Util.Teste
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void ValidarDespesaParaSalvar()
        {

            //arrange
            var despesa = new Despesa
            {
                Id = Guid.NewGuid(),
                Descricao = "Roupa", 
                Categoria = null, 
                Casal = false, 
                MesReferencia = "09/10", 

            };

            var despesaCerta = new Despesa
            {
                Id = Guid.NewGuid(),
                Descricao = "Roupa",
                Categoria = new Categoria(),
                Casal = false,
                MesReferencia = "09/10",
                TipoPagamento = "ok"
            };

            var mock = new Mock<IDespesaService>();
            mock.Setup(d => d.ValidarDespesa(despesa)).Returns(false);
            var verify = new DespesaService();

            //act
            var resultadoEsperado = mock.Object.ValidarDespesa(despesa);
            var resultado = verify.ValidarDespesa(despesa);

            //assert
            Assert.AreEqual(resultado, resultadoEsperado);

        }
    }
}
