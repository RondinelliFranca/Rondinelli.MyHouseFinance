using System.Web;
using Rondinelli.MyHouseFinance.Infra.Data.Interfaces;

namespace Rondinelli.MyHouseFinance.Infra.Data.Contexts
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        private static MyHouseFinanceContext context = null;

        public MyHouseFinanceContext GetContext()
        {
            if (HttpContext.Current == null)
            {
                if (context == null)
                {
                    context = new MyHouseFinanceContext();
                }
                return context;
            }
            else if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new MyHouseFinanceContext();
            }
            return (MyHouseFinanceContext)HttpContext.Current.Items[ContextKey];
        }
    }
}