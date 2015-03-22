using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dancenew.Startup))]
namespace dancenew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
