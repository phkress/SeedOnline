using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(infTeam.Startup))]
namespace infTeam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
