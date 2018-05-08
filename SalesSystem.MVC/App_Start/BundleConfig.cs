using System.Web.Optimization;

namespace SalesSystem.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/masks").Include(
                "~/Scripts/jquery.moneymask.js",
                "~/Scripts/jquery.maskedinput.min.js",
                "~/Scripts/bootstrap-datepicker.js",
                "~/Scripts/jquery-ui.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/init").Include(
                "~/Scripts/init.js",
                "~/Scripts/main.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/site.css"));
        }
    }
}
