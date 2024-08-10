using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TomatosPizzeria.Startup))]
namespace TomatosPizzeria
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
