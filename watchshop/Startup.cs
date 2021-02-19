using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BT08.Startup))]
namespace BT08
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
