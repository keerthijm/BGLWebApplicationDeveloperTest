using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JmkWebAppDeveTest.Startup))]
namespace JmkWebAppDeveTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
