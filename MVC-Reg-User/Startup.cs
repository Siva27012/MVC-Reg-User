using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Reg_User.Startup))]
namespace MVC_Reg_User
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
