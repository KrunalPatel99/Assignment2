using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZeusSystem.Startup))]
namespace ZeusSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
