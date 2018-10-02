using System.Web;
using System.Web.Optimization;

namespace Rondinelli.MyHouseFinance.UI.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/moment-with-locales.min.js",
                        "~/Scripts/bootstrap-datetimepicker.min.js",
                        "~/Scripts/generic/generic.datetimepicker.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/mask").Include(
                "~/Scripts/jquery.mask.js",
                "~/Scripts/generic/generic.save.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region dateTimePicker

            bundles.Add(new StyleBundle("~/Content/datetimepickercss").Include(
                "~/Content/bootstrap-datetimepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/bootstrap-datetimepicker.min.js",
                "~/Scripts/generic/generic.datetimepicker.js"));

            #endregion

            #region Despesa

            bundles.Add(new ScriptBundle("~/bundles/despesas").Include(
                "~/Scripts/despesa/despesa.js"
            ));

            #region Relatorio

            bundles.Add(new ScriptBundle("~/bundles/relatorio").Include(
                "~/Scripts/relatorio/relatorios.js"
            ));

            #endregion

            #endregion
        }
    }
}
