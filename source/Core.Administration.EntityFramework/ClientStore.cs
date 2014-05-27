using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration.Models;
using Thinktecture.IdentityServer.Core.Administration.Stores;
using Thinktecture.IdentityServer.Core.EntityFramework;

namespace Thinktecture.IdentityServer.Core.Administration.EntityFramework
{
    public class ClientStore : IClientStore
    {
        protected CoreDbContext db;

        public ClientStore(CoreDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Models.ClientSummary> Query(string filter)
        {
            var query =
                from c in db.Clients
                select c;
            if (!String.IsNullOrWhiteSpace(filter))
            {
                query =
                    from c in query
                    where c.ClientName.Contains(filter) || c.ClientId.Contains(filter)
                    select c;
            }

            var results = 
                from c in query
                select new ClientSummary
                {
                    ClientId = c.ClientId,
                    Name = c.ClientName
                };

            return results;
        }

        public Core.Models.Client Get(string clientId)
        {
            return db.Clients.SingleOrDefault(x => x.ClientId == clientId).ToModel();
        }

        public void Upsert(Core.Models.Client client)
        {
            //throw new NotImplementedException();
        }

        public void Delete(string clientId)
        {
            var item = db.Clients.SingleOrDefault(x => x.ClientId == clientId);
            if (item != null)
            {
                db.Clients.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
