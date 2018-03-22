using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QueueManagement.Mvc.Startup))]
namespace QueueManagement.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
