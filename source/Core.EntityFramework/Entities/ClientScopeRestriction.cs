using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class ClientScopeRestriction
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        public virtual string Scope { get; set; }

        public virtual Client Client { get; set; }
    }
}
