using System.Web;
using System.Web.Optimization;

namespace EgitimPlatformu
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/html5shiv.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/wow.min.js",
                      "~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                    "~/admin/js/jquery.js",
                    "~/admin/js/bootstrap.min.js",
                    "~/admin/js/plugins/morris/raphael.min.js",
                    "~/admin/js/plugins/morris/morris.min.js",
                    "~/admin/js/plugins/morris/morris-data.js"
                    ));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome.min.css",
                      "~/Content/css/font.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/structure.css"));

            bundles.Add(new StyleBundle("~/admin/css").Include(
                      "~/admin/css/bootstrap.min.css",
                      "~/admin/css/sb-admin.css",
                      "~/admin/css/plugins/morris.css",
                      "~/admin/font-awesome/css/font-awesome.min.css"
                      ));
        }
    }
}
