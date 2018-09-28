using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rondinelli.MyHouseFinance.Domain.Entities;
using Rondinelli.MyHouseFinance.Infra.Data.EntityConfig;

namespace Rondinelli.MyHouseFinance.Infra.Data.Contexts
{
    public class MyHouseFinanceContext : DbContext
    {
        public MyHouseFinanceContext()
           : base("MyHouseFinanceContext")
        {

        }

        #region DBSet
         
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<StoreGeneratedIdentityKeyConvention>();


            //Configurações padrões
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType?.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("nvarchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(200));

            modelBuilder.Configurations.Add(new DespesaConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());


            base.OnModelCreating(modelBuilder);
        }
    }
}