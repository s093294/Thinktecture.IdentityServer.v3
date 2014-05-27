using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Thinktecture.IdentityServer.Core.Administration.Stores;
using Thinktecture.IdentityServer.Core.Administration.Validation;

namespace Thinktecture.IdentityServer.Core.Administration
{
    class AutofacConfig
    {
        public static IDependencyResolver Configure(IdentityServerAdministrationOptions config)
        {
            if (config == null) throw new ArgumentNullException("config");

            var builder = new ContainerBuilder();

            builder
                .Register(ctx => config.ServiceFactory.ClientFactory())
                .As<IClientStore>()
                .InstancePerRequest();
            builder
                .Register(ctx => config.ServiceFactory.ScopeFactory())
                .As<IScopeStore>()
                .InstancePerRequest();

            builder.RegisterType<ClientValidator>().AsSelf();
            
            builder
                .RegisterApiControllers(typeof(AutofacConfig).Assembly);

            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }
    }
}
