using System;
using System.Collections.Generic;

namespace Rondinelli.MyHouseFinance.Domain.Entities
{
    public class Categoria
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Despesa> ListaDespesa { get; set; }

    }
}