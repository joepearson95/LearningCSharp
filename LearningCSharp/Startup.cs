using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningCSharp.Startup))]
namespace LearningCSharp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
