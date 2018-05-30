using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ArtClubFinal.Startup))]
namespace ArtClubFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
