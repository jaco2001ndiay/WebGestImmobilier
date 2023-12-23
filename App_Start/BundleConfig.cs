using System.Web;
using System.Web.Optimization;

namespace WebGestImmobilier
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/vendor/owl-carousel").Include(
                "~/asset/vendor/owl-carousel/css/owl.carousel.min.css",
                "~/asset/vendor/owl-carousel/css/owl.theme.default.min.css"
                )) ;

            bundles.Add(new StyleBundle("~/vendor/jqvmap").Include(
                "~/asset/vendor/jqvmap/css/jqvmap.min.css")
                ); 

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

         

            bundles.Add(new StyleBundle("~/asset/css").Include(
                     "~/asset/css/bootstrap.css",
                     "~/asset/css/site.css",
                      "~/asset/css/style.css"));
            bundles.Add(new ScriptBundle("~/asset/js").Include(
              
                "~/asset/js/layout-compact-nav.js",
                "~/asset/js/layout-dark.js",
                "~/asset/js/layout-fixed-header.js",
                "~/asset/js/layout-fixed-anv.js",
                "~/asset/js/layout-full-nav.js",
                "~/asset/js/layout-light.js",
                "~/asset/js/layout-mini-nav.js",
                "~/asset/js/layout-rtl.js",
               
                "~/asset/js/settings.js",
                "~/asset/js/styleSwitcher.js"));
            bundles.Add(new StyleBundle("~/asset/scss/layout/footer").Include(
                "~/asset/scss/layout/footer/_footer.scss"
                )); 

            bundles.Add(new StyleBundle("~/asset/scss/layout/header").Include(
                ));
            bundles.Add(new ScriptBundle("~/asset/vendor/global").Include(
                "~/asset/vendor/global/global.min.js"
                )); 
            bundles.Add(new ScriptBundle("~/asset/js/quixnav").Include(
                 "~/asset/js/quixnav-init.js",
                 "~/asset/js/custom.min.js")); 
            bundles.Add(new ScriptBundle("~/asset/vendor/vectormap").Include(
                "~/asset/vendor/raphael/raphael.min.js",
                "~/asset/vendor/morris/morris.min.js",
                "~/asset/vendor/circle-progress/circle-progress.min.js",
                "~/asset/vendor/chart.js/Chart.bundle.min.js",
                "~/asset/vendor/gaugeJS/dist/gauge.min.js"

                ));

            bundles.Add(new ScriptBundle("~/asset/vendor/flotchart").Include(
                "~/asset/vendor/flot/jquery.flot.js",
                "~/asset/vendor/flot/jquery.flot.resize.js"
                ));
            bundles.Add(new ScriptBundle("~/asset/vendor/owlcarrosel").Include(
                "~/asset/vendor/owl-carousel/js/owl.carousel.min.js"));
            bundles.Add(new ScriptBundle("~/asset/vendor/counterup").Include(
                "~/asset/vendor/jqvmap/js/jquery.vmap.min.js",
                "~/asset/vendor/jqvmap/js/jquery.vmap.usa.js",
                "~/asset/vendor/jquery.counterup/jquery.counterup.min.js"));
            bundles.Add(new ScriptBundle("~/asset/js/dashboard").Include(
                "~/asset/js/dashboard/dashboard-1.j")); 

        }
    }
}
