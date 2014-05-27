using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Thinktecture.IdentityServer.Core.Administration.Api
{
    public class MetaController : ApiController
    {
        [Route]
        public IHttpActionResult Get()
        {
            return Ok(new {
                clients = Url.Link("clients", null),
                scopes = Url.Link("scopes", null),
            });
        }
    }
}
