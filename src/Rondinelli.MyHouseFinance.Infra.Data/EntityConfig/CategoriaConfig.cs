using System.Data.Entity.ModelConfiguration;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Infra.Data.EntityConfig
{
    public class CategoriaConfig : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfig()
        {
            ToTable("Categorias");

            HasKey(x => x.Id);

            Property(x => x.Nome)
                .IsRequired();
        }
    }
}