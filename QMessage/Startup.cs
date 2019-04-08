using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QMessage.Startup))]
namespace QMessage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
