using System.Data.Entity.ModelConfiguration;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuarios");

            HasKey(x => x.Id);

            Property(x => x.Nome).IsRequired();
            Property(x => x.CategoriaPessoa).IsRequired();
        }
    }
}