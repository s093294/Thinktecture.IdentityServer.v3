using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityServer.Core.Administration;

namespace Thinktecture.IdentityServer.AdministrationHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerAdministration(
                new IdentityServerAdministrationOptions
                {
                });
        }
    }
}