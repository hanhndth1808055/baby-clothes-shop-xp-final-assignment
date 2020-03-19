using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AssignmentBabyClothes.Startup))]
namespace AssignmentBabyClothes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
