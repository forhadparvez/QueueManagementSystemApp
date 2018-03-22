using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QueueManagement.WebForm.Startup))]
namespace QueueManagement.WebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
