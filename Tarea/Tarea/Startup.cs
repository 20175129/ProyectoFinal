using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tarea.Startup))]
namespace Tarea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
