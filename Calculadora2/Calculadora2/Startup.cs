using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Calculadora2.Startup))]
namespace Calculadora2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
