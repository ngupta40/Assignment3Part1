using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TryItAssignment3.Startup))]
namespace TryItAssignment3
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
