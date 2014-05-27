using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace Thinktecture.IdentityServer.Core.Administration
{
    class WebApiConfig
    {
        public static void Configure(IAppBuilder app, IDependencyResolver resolver, IdentityServerAdministrationOptions config)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (resolver == null) throw new ArgumentNullException("resolver");
            if (config == null) throw new ArgumentNullException("config");

            var apiConfig = new HttpConfiguration();
            apiConfig.MapHttpAttributeRoutes();
            apiConfig.DependencyResolver = resolver;

            apiConfig.SuppressDefaultHostAuthentication();
            apiConfig.Filters.Add(new HostAuthenticationAttribute("Bearer"));
            //apiConfig.Filters.Add(new AuthorizeAttribute(){Roles=config.AdminRoleName});

            apiConfig.Formatters.Remove(apiConfig.Formatters.XmlFormatter);
            apiConfig.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            //apiConfig.Services.Add(typeof(IExceptionLogger), new UserAdminExceptionLogger());

            app.UseWebApi(apiConfig);
        }
    }
}
