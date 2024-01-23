using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace TaxiBooking
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-3.4.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-validate/jquery.validate.min.js",
                        "~/Scripts/jquery-validate/additional-methods.min.js"));

          bundles.Add(new ScriptBundle("~/bundles/dataTable").Include(
                        "~/Scripts/datatables/js/datatables.min.js",
                        "~/Scripts/datatables/js/dataTables.buttons.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Scripts/sweetalert2/sweetalert2.min.css",
                      "~/Scripts/datatables/css/datatables.min.css",
                      "~/Scripts/datatables/css/buttons.dataTables.min.css"));
            bundles.Add(new Bundle("~/bundles/popper").Include(
                       "~/Scripts/popper.min.js"));
            bundles.Add(new Bundle("~/bundles/login").Include(
                      "~/Scripts/login.js"));
            bundles.Add(new Bundle("~/bundles/modal").Include(
                      "~/Scripts/modal.js"));
            bundles.Add(new Bundle("~/bundles/booking-crud").Include(
                      "~/Scripts/booking-crud-jquery.js"));
            bundles.Add(new Bundle("~/bundles/sweetalert2").Include(
                      "~/Scripts/sweetalert2/sweetalert2.min.js"));
        }
    }
}
