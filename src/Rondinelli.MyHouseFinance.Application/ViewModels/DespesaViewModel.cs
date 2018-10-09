using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Rondinelli.MyHouseFinance.Application.ViewModels
{
    public class DespesaViewModel
    {
        public DespesaViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        [Display(Name = "Descrição")]
        [StringLength(200)]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Mês de Refêrencia")]
        [StringLength(15)]
        [Required]
        public string MesReferencia { get; set; } 

        [Required]
        public decimal Valor { get; set; }

        [Display(Name = "Data da Compra")]
        [Required]
        public DateTime? DataCompra { get; set; } = DateTime.Now;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O valor {0} da parcela não pode ser menor que 1.")]
        public int Parcelas { get; set; } = 1;

        [Display(Name = "Tipo do pagamento")]
        [Required]
        public string TipoPagamento { get; set; }

        [Display(Name = "É do casal?")]
        public bool Casal { get; set; } = true;

        [Display(Name = "Dividir essa despesa?")]
        public bool DividirDespesa { get; set; } = false;

        public UsuarioViewModel ResponsavelPagador { get; set; }

        [Display(Name = "Responsável")]
        public Guid? ResponsavelPagadorId { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }

        public List<string> Ids { get; set; }
    }
}