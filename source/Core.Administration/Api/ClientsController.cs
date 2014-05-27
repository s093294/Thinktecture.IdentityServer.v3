using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Thinktecture.IdentityServer.Core.Models;
using System.Net;

using Thinktecture.IdentityServer.Core.Administration.Extensions;
using Thinktecture.IdentityServer.Core.Administration.Stores;
using Thinktecture.IdentityServer.Core.Administration.Validation;
using Thinktecture.IdentityServer.Core.Administration.Models;

namespace Thinktecture.IdentityServer.Core.Administration.Api
{
    public class ClientsController : ApiController
    {
        IClientStore clientStore;
        ClientValidator clientValidator;

        public ClientsController(IClientStore clientStore, ClientValidator clientValidator)
        {
            this.clientStore = clientStore;
            this.clientValidator = clientValidator;
        }

        [Route("clients", Name="clients")]
        public IHttpActionResult GetClients(string filter = null)
        {
            var data = clientStore.Query(filter);
            var result =
                from item in data
                select new Payload
                {
                    Data = item,
                    Links = new Link[] { 
                        new Link{
                            Rel = "details",
                            Href = Url.Link("client", new{clientId = item.ClientId})
                        }
                    }
                };
            return Ok(result);
        }

        [Route("clients/{clientId}", Name="client")]
        public IHttpActionResult GetClient(string clientId)
        {
            var item = clientStore.Get(clientId);
            if (item == null) return NotFound();

            var result = new Payload
            {
                Data = item,
                Links = new Link[]{
                    new Link { Rel = "update", Href = Url.Link("client", new { clientId }) },
                    new Link { Rel = "delete", Href = Url.Link("client", new { clientId }) },
                }
            };
            return Ok(result);
        }
        
        [Route("clients/{clientId}")]
        public IHttpActionResult Put(string clientId, Client client)
        {
            if (client == null)
            {
                ModelState.AddModelError("", "No data submitted");
            }

            client.ClientId = clientId;

            if (!ModelState.IsValid)
            {
                return ResponseMessage(Request.CreateResponse(
                    HttpStatusCode.BadRequest,
                    ModelState.ToValidationResult()));
            }

            var result = clientValidator.Validate(client);
            if (!result.Success)
            {
                return ResponseMessage(Request.CreateResponse(
                    HttpStatusCode.BadRequest, result));
            }

            this.clientStore.Upsert(client);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }

        [Route("clients/{clientId}")]
        public IHttpActionResult Delete(string clientId)
        {
            var item = this.clientStore.Get(clientId);
            if (item == null)
            {
                return NotFound();
            }

            this.clientStore.Delete(clientId);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NoContent));
        }
    }
}
