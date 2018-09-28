using System;
using System.Collections;
using System.Collections.Generic;

namespace Rondinelli.MyHouseFinance.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CategoriaPessoa { get; set; }
        public virtual ICollection<Despesa> ListaDespesa { get; set; }
    }
}