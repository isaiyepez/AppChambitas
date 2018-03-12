using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppChambitasV1.Backend.Startup))]
namespace AppChambitasV1.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
