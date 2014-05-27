using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Models;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Core.Administration.Stores
{
    public interface IClientStore
    {
        IEnumerable<ClientSummary> Query(string filter);
        Client Get(string clientId);
        void Upsert(Client client);
        void Delete(string clientId);
    }
}
