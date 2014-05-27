using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thinktecture.IdentityServer.Core.EntityFramework.Entities
{
    public class ClientRedirectUri
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        public virtual string Uri { get; set; }

        public virtual Client Client { get; set; }
    }
}
