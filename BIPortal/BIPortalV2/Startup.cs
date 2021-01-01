using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BIPortalV2.Startup))]
namespace BIPortalV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
