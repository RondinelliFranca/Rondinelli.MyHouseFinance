using System.Data.Entity.ModelConfiguration;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Infra.Data.EntityConfig
{
    public class DespesaConfig : EntityTypeConfiguration<Despesa>
    {
        public DespesaConfig()
        {
            ToTable("Despesas");

            HasKey(x => x.Id);

            Property(x => x.MesReferencia).IsRequired();
            Property(x => x.Valor).IsRequired();
            Property(x => x.TipoPagamento).IsRequired();

            HasRequired(x => x.ResponsavelPagador)
                .WithMany(d => d.ListaDespesa)
                .HasForeignKey(x => x.ResponsavelPagadorId);

            HasRequired(x => x.Categoria)
                .WithMany(c => c.ListaDespesa)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}