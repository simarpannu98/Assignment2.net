using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASP_assignment.Startup))]
namespace ASP_assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
