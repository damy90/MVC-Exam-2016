using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(UserVoice.Web.Startup))]

namespace UserVoice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
