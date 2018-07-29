using System.Web;
using System.Web.Optimization;

namespace BCSProject
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Content/Scripts/jquery-{version}.js",
                      "~/Content/Scripts/respond.js",
                      "~/Content/Scripts/datatables/jquery.datatables.js",
                      "~/Content/Scripts/datatables/datatables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Content/Scripts/bootstrap.js",
                        "~/Content/Scripts/popper.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/tagsinput").Include(
                        "~/Content/Scripts/bootstrap-tagsinput.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Content/Scripts/jquery-ui.js"));

            //employee
            bundles.Add(new ScriptBundle("~/scripts/employee/create").Include(
                        "~/Content/Scripts/Site/employee/create.js"));
            bundles.Add(new ScriptBundle("~/scripts/employee/edit").Include(
                        "~/Content/Scripts/Site/employee/edit.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/datatables/css/datatables.bootstrap4.css",
                      "~/Content/Css/site.css",
                      "~/Content/Css/layout.css",
                      "~/Content/Css/jquery-ui.css",
                      "~/Content/Css/bootstrap-tagsinput-typehead.css",
                      "~/Content/Css/bootstrap-tagsinput.css"));
        }
    }
}
