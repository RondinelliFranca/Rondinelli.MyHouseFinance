using System;
using System.Collections.Generic;

namespace Rondinelli.MyHouseFinance.Domain.Entities
{
    public class Despesa
    {
        public Despesa()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string MesReferencia { get; set; }
        public decimal Valor { get; set; }
        public DateTime? DataCompra { get; set; }
        public int Parcelas { get; set; }
        public string TipoPagamento { get; set; }
        public bool Casal { get; set; }
        public virtual Usuario ResponsavelPagador { get; set; }
        public Guid ResponsavelPagadorId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public bool DividirDespesa { get; set; }
        public List<string> Ids { get; set; }

    }
}