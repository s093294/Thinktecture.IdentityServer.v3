using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Services;

namespace Thinktecture.IdentityServer.Core.EntityFramework
{
    public class ClientService : IClientService
    {
        protected CoreDbContext db;
        public ClientService(CoreDbContext db)
        {
            this.db = db;
        }

        public Task<Models.Client> FindClientByIdAsync(string clientId)
        {
            var client = db.Clients
                .Include("RedirectUris")
                .Include("ScopeRestrictions")
                .SingleOrDefault(x => x.ClientId == clientId);

            return Task.FromResult(client.ToModel());
        }
    }
}
