using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWorkd_old_form.Startup))]
namespace HelloWorkd_old_form
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
