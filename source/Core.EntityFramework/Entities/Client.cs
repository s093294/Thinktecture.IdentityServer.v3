using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Models;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class Client
    {
        public virtual int ID { get; set; }
        public virtual bool Enabled { get; set; }

        public virtual string ClientId { get; set; }
        public virtual string ClientSecret { get; set; }
        public virtual string ClientName { get; set; }
        public virtual string ClientUri { get; set; }
        public virtual string LogoUri { get; set; }

        public virtual bool RequireConsent { get; set; }
        public virtual bool AllowRememberConsent { get; set; }

        public virtual Flows Flow { get; set; }

        // in seconds
        public virtual int IdentityTokenLifetime { get; set; }
        public virtual int AccessTokenLifetime { get; set; }
        public virtual int RefreshTokenLifetime { get; set; }
        public virtual int AuthorizationCodeLifetime { get; set; }

        public virtual SigningKeyTypes IdentityTokenSigningKeyType { get; set; }
        public virtual AccessTokenType AccessTokenType { get; set; }

        // not implemented yet
        public virtual bool RequireSignedAuthorizeRequest { get; set; }
        public virtual SubjectTypes SubjectType { get; set; }
        public virtual string SectorIdentifierUri { get; set; }
        public virtual ApplicationTypes ApplicationType { get; set; }

        public virtual ICollection<ClientRedirectUri> RedirectUris { get; set; }
        public virtual ICollection<ClientScopeRestriction> ScopeRestrictions { get; set; }
    }
}
