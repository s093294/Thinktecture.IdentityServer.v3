using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.EntityFramework.Entities;

namespace Thinktecture.IdentityServer.Core.EntityFramework
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DbSet<Entities.Client> Clients { get; set; }
        public DbSet<Entities.Scope> Scopes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasMany(x => x.RedirectUris).WithRequired(x => x.Client).WillCascadeOnDelete();
            modelBuilder.Entity<Client>()
                .HasMany(x => x.ScopeRestrictions).WithRequired(x => x.Client).WillCascadeOnDelete();
            modelBuilder.Entity<Scope>()
                .HasMany(x => x.ScopeClaims).WithRequired(x=>x.Scope).WillCascadeOnDelete();
        }
    }
}
