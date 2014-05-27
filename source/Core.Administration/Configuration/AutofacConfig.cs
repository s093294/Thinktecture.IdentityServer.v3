using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace Thinktecture.IdentityServer.Core.Administration
{
    class AutofacConfig
    {
        public static IDependencyResolver Configure(IdentityServerAdministrationOptions config)
        {
            if (config == null) throw new ArgumentNullException("config");

            var builder = new ContainerBuilder();
            //builder
            //    .Register(ctx => config.UserManagerFactory())
            //    .As<IUserManager>()
            //    .InstancePerApiRequest();
            builder
                .RegisterApiControllers(typeof(AutofacConfig).Assembly);

            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }
    }
}
