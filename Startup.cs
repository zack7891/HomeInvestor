using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeInvestor.Startup))]
namespace HomeInvestor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
