using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BCSProject.Startup))]
namespace BCSProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
