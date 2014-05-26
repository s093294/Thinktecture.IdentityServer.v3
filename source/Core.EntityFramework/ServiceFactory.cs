using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Models;
using Thinktecture.IdentityServer.Core.Services;

namespace Thinktecture.IdentityServer.Core.EntityFramework
{
    public class ServiceFactory
    {
        string connectionString;
        public ServiceFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IClientService CreateClientService()
        {
            return new DisposableClientService(connectionString);
        }
        
        public IScopeService CreateScopeService()
        {
            return new DisposableScopeService(connectionString);
        }

        public void ConfigureClients(IEnumerable<Client> clients)
        {
            using (var db = new CoreDbContext(connectionString))
            {
                if (!db.Clients.Any())
                {
                    foreach (var c in clients)
                    {
                        var e = c.ToEntity();
                        db.Clients.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }
        
        public void ConfigureScopes(IEnumerable<Scope> scopes)
        {
            using (var db = new CoreDbContext(connectionString))
            {
                if (!db.Scopes.Any())
                {
                    foreach (var s in scopes)
                    {
                        var e = s.ToEntity();
                        db.Scopes.Add(e);
                    }
                    db.SaveChanges();
                }
            }
        }

        class DisposableClientService : ClientService, IDisposable
        {
            public DisposableClientService(string connectionString)
                : base(new CoreDbContext(connectionString))
            {
            }

            public void Dispose()
            {
                this.db.Dispose();
            }
        }

        class DisposableScopeService : ScopeService, IDisposable
        {
            public DisposableScopeService(string connectionString)
                : base(new CoreDbContext(connectionString))
            {
            }

            public void Dispose()
            {
                this.db.Dispose();
            }
        }
    }
}
