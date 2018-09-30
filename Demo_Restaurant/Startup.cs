using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_Restaurant.Startup))]
namespace Demo_Restaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
