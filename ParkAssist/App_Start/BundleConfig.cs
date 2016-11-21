using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ParkAssist
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor")
                   .Include("~/Scripts/jquery-1.10.2.min.js")
                   .Include("~/Scripts/bootstrap.min.js")
                   .Include("~/Scripts/angular.min.js")
                   .Include("~/Scripts/AngularUI/ui-router.min.js")
                   .Include("~/Scripts/smart-table.min.js")
                   );

            bundles.Add(new ScriptBundle("~/bundles/custom")
                .IncludeDirectory("~/Apps/", "*.js", true)
                .IncludeDirectory("~/Apps/services", "*.js", true)
                .IncludeDirectory("~/Apps/controllers", "*.js", true)
                .IncludeDirectory("~/Apps/directives", "*.js", true)
                .IncludeDirectory("~/Apps/templates", "*.js", true));


            bundles.Add(new StyleBundle("~/Content/Styles/css")
                .Include("~/Content/bootstrap/bootstrap-3.3.5.css")
                .Include("~/Content/bootstrap-additions/bootstrap-additions.css")
                .Include("~/Content/fontawesome/font-awesome-4.4.0.css")
                .Include("~/Content/flag-icon/flag-icon.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/morris.core.css")
                .Include("~/Content/nProgress.css")
                .Include("~/Content/transitions.css")
                .Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Styles/Ltecss")
                .Include("~/Content/bootstrap/bootstrap-3.3.5.css")
                .Include("~/Content/bootstrap-additions/bootstrap-additions.css")
                .Include("~/Content/fontawesome/font-awesome-4.4.0.css")
                .Include("~/Content/flag-icon/flag-icon.css")
                .Include("~/Content/ionicons/ionicons.css")
                .Include("~/Content/toastr.css")
                .Include("~/Content/morris.core.css")
                .Include("~/Content/nProgress.css")
                .Include("~/Content/fullcalendar.css")
                .Include("~/Content/transitions.css")
                .Include("~/Content/AdminLte-2.0.2/AdminLte.css")
                .Include("~/Content/AdminLte-2.0.2/skins/skin-blue.css")
                .Include("~/Content/site.css"));
        }
    }
}