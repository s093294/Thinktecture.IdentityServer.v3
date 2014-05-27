using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thinktecture.IdentityServer.Core.Administration;
using Thinktecture.IdentityServer.Core.Administration.EntityFramework;

namespace Thinktecture.IdentityServer.AdministrationHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var efFactory = new Factory("name=idsrv3config");
            app.UseIdentityServerAdministration(
                new IdentityServerAdministrationOptions
                {
                    ServiceFactory = new StoreFactory
                    {
                        ClientFactory = efFactory.CreateClientStore,
                        ScopeFactory = efFactory.CreateScopeStore
                    }
                });
        }
    }
}