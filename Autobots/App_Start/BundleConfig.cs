using System.Web;
using System.Web.Optimization;

namespace Autobots
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            #region FrontScripts
            bundles.Add(new ScriptBundle("~/Content/Front").Include(
                "~/Content/Front/js/jquery.min.js",
                "~/Content/Front/js/bootstrap.min.js",
                "~/Content/Front/js/jquery.easing.min.js",
                "~/Content/Front/js/masterslider.min.js",
                "~/Content/Front/js/revolution-slider/jquery.themepunch.tools.min.js",
                "~/Content/Front/js/revolution-slider/jquery.themepunch.revolution.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.actions.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.carousel.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.kenburn.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.layeranimation.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.migration.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.navigation.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.parallax.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.slideanims.min.js",
                "~/Content/Front/js/revolution-slider/extensions/revolution.extension.video.min.js",
                "~/Content/Front/js/jquery.mixitup.min.js",
                "~/Content/Front/js/pignose.gallery.min.js",
                "~/Content/Front/js/jquery.fancybox.pack.js",
                "~/Content/Front/js/hexagons.min.js",
                "~/Content/Front/js/simplePlayer.js",
                "~/Content/Front/js/jquery.collapse,js",
                "~/Content/Front/js/jquery.smartmenus.js",
                "~/Content/Front/js/jquery.smartmenus.bootstrap.js",
                "~/Content/Front/js/jquery.isotope.js" ,
                "~/Content/Front/js/jquery-ui.min.js",
                "~/Content/Front/js/owl.carousel.js",
                "~/Content/Front/js/main.js",
                "~/Content/Front/js/bootstrapValidator.min.js"

                ));
            
             
            #endregion





            #region UBold Admin Styles

            bundles.Add(new StyleBundle("~/css/maincss").Include(
                      "~/Content/Back/assets/css/bootstrap.min.css",
                      "~/Content/Back/assets/css/core.css",
                      "~/Content/Back/assets/css/components.css",
                      "~/Content/Back/assets/css/icons.css",
                      "~/Content/Back/assets/css/pages.css",
                      "~/Content/Back/assets/css/bootstrap.min.css.map",
                      "~/Content/Back/assets/css/responsive.css",
                      "~/Content/Back/assets/css/typicons.css",

                      "~/Content/Back/assets/plugins/custombox/css/custombox.css",
                      "~/Content/Back/assets/plugins/bootstrap-sweetalert/sweet-alert2.css"));
            #endregion

            #region UBold Admin Scripts

            bundles.Add(new ScriptBundle("~/JS/MainJS").Include(
                      "~/Content/Back/assets/js/jquery.min.js",
                      "~/Content/Back/assets/js/bootstrap.min.js",
                      "~/Content/Back/assets/js/detect.js",
                      "~/Content/Back/assets/js/fastclick.js",
                      "~/Content/Back/assets/js/jquery.slimscroll.js",
                      "~/Content/Back/assets/js/jquery.blockUI.js",
                      "~/Content/Back/assets/js/waves.js",
                      "~/Content/Back/assets/js/wow.min.js",
                      "~/Content/Back/assets/js/jquery.core.js",
                      "~/Content/Back/assets/js/jquery.app.js",
                      "~/Content/Back/assets/js/jquery.nicescroll.js",
                      "~/Content/Back/assets/js/jquery.scrollTo.min.js",

                      "~/Content/Back/assets/plugins/notifyjs/js/notify.js",
                      "~/Content/Back/assets/plugins/notifications/notify-metro.js",
                      "~/Content/Back/assets/plugins/peity/jquery.peity.min.js",
                      "~/Content/Back/assets/plugins/waypoints/lib/jquery.waypoints.js",
                      "~/Content/Back/assets/plugins/counterup/jquery.counterup.min.js",

                     // "~/Content/Back/assets/js/modernizr.min.js",
                      "~/Content/Back/assets/plugins/raphael/raphael-min.js",
                      "~/Content/Back/assets/plugins/jquery-knob/jquery.knob.js",
                      //"~/Content/Back/assets/pages/jquery.dashboard.js",
                      "~/Content/Back/assets/plugins/custombox/js/custombox.min.js",
                      "~/Content/Back/assets/plugins/custombox/js/legacy.min.js",
                      "~/Content/Back/assets/plugins/bootstrap-sweetalert/sweet-alert2.js"));

            #endregion



            #region Editable datatables scripts
            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/Content/Back/assets/plugins/magnific-popup/js/jquery.magnific-popup.min.js",
                "~/Content/Back/assets/plugins/jquery-datatables-editable/jquery.dataTables.js",
                "~/Content/Back/assets/plugins/datatables/dataTables.bootstrap.js",
                "~/Content/Back/assets/plugins/tiny-editable/mindmup-editabletable.js",
                 "~/Content/Back/assets/plugins/tiny-editable/numeric-input-example.js",
                 "~/Content/Back/assets/pages/datatables.editable.init.js"

                ));


            #endregion



            #region Buttons datatables scripts
            bundles.Add(new ScriptBundle("~/bundles/buttontables").Include(
                "~/Content/Back/assets/plugins/datatables/jquery.dataTables.min.js",
                "~/Content/Back/assets/plugins/datatables/dataTables.bootstrap.js",
                "~/Content/Back/assets/plugins/datatables/dataTables.buttons.min.j",
                "~/Content/Back/assets/plugins/datatables/buttons.bootstrap.min.js",
                "~/Content/Back/assets/plugins/datatables/jszip.min.js",
                "~/Content/Back/assets/plugins/datatables/pdfmake.min.js",
                "~/Content/Back/assets/plugins/datatables/vfs_fonts.js",
                "~/Content/Back/assets/plugins/datatables/buttons.html5.min.js",
                "~/Content/Back/assets/plugins/datatables/buttons.print.min.js",
                "~/Content/Back/assets/pages/datatables.init.js"

                ));
            #endregion

            #region Buttons datatables styles




            bundles.Add(new StyleBundle("~/bundles/buttontablesstyles").Include(

                "~/Content/Back/assets/plugins/datatables/jquery.dataTables.min.css",
                "~/Content/Back/assets/plugins/datatables/buttons.bootstrap.min.css",
                "~/Content/Back/assets/plugins/datatables/responsive.bootstrap.min.css",
                "~/Content/Back/assets/plugins/datatables/dataTables.bootstrap.min.css"
                ));
            #endregion







        }
    }
}
