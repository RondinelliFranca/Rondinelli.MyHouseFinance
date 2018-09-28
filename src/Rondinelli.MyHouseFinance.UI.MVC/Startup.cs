using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rondinelli.MyHouseFinance.UI.MVC.Startup))]
namespace Rondinelli.MyHouseFinance.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
