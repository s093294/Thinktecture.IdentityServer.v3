using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Stores;

namespace Thinktecture.IdentityServer.Core.Administration
{
    public class StoreFactory
    {
        public Func<IClientStore> ClientFactory { get; set; }
        public Func<IScopeStore> ScopeFactory { get; set; }
    }
}
