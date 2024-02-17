using System.Globalization;
using System.Threading;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebGestImmobilier.Startup))]
namespace WebGestImmobilier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configuration de la localisation
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("fr-FR"),
                // Ajoutez d'autres cultures prises en charge ici
            };

            Thread.CurrentThread.CurrentCulture = supportedCultures[1];
            Thread.CurrentThread.CurrentUICulture = supportedCultures[1];

            ConfigureAuth(app);
        }
    }
}
