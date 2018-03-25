using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiYo.Startup))]
namespace MiYo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
