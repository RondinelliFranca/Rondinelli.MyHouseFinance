using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Ninject.Modules;
using Rondinelli.MyHouseFinance.Application.AppService;
using Rondinelli.MyHouseFinance.Application.Interfaces;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Repository;
using Rondinelli.MyHouseFinance.Domain.Interfaces.Service;
using Rondinelli.MyHouseFinance.Domain.Service;
using Rondinelli.MyHouseFinance.Infra.Data.Contexts;
using Rondinelli.MyHouseFinance.Infra.Data.Interfaces;
using Rondinelli.MyHouseFinance.Infra.Data.Repository;
using Rondinelli.MyHouseFinance.Infra.Data.UoW;

namespace Rondinelli.MHF.Infra.CrossCutting.IoC
{
    internal class Modulo : NinjectModule
    {
        public override void Load()
        {
            #region App

            Bind<IDespesaAppService>().To<DespesaAppService>();
            Bind<IUsuarioAppService>().To<UsuarioAppService>();
            Bind<ICategoriaAppService>().To<CategoriaAppService>();
            Bind<IRelatorioAppService>().To<RelatorioAppService>();

            #endregion

            #region Domain

            Bind<IDespesaService>().To<DespesaService>();
            Bind<IUsuarioService>().To<UsuarioService>();
            Bind<ICategoriaService>().To<CategoriaService>();

            #endregion

            #region Data

            Bind<IDespesaRepository>().To<DespesaRepository>();
            Bind<IUsuarioRepository>().To<UsuarioRepository>();
            Bind<ICategoriaRepository>().To<CategoriaRepository>();

            #endregion

            #region Context

            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IContextManager>().To<ContextManager>();

            #endregion

        }
    }
}