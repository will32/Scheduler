using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Scheduler.Startup))]
namespace Scheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
