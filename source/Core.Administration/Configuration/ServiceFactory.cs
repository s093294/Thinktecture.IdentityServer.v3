using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Services;

namespace Thinktecture.IdentityServer.Core.Administration
{
    public class ServiceFactory
    {
        public Func<IClientService> ClientServiceFactory { get; set; }
        public Func<IScopeService> ScopeServiceFactory { get; set; }
    }
}
