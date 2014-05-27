using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Thinktecture.IdentityServer.Core.Administration.Api
{
    public class ScopesController : ApiController
    {
        [Route("scopes", Name="scopes")]
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
