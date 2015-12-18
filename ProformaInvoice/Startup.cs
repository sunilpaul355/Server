using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProformaInvoice.Startup))]
namespace ProformaInvoice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
