using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebGestImmobilier.Startup))]
namespace WebGestImmobilier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
