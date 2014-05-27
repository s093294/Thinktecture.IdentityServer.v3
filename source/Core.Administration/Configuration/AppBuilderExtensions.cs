using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thinktecture.IdentityServer.Core.Administration;

namespace Owin
{
    public static class AppBuilderExtensions
    {
        public static IAppBuilder UseIdentityServerAdministration(
            this IAppBuilder app, 
            Thinktecture.IdentityServer.Core.Administration.IdentityServerAdministrationOptions config)
        {
            if (app == null) throw new ArgumentNullException("app");
            if (config == null) throw new ArgumentNullException("config");
            //config.Validate();

            app.Use(async (ctx, next) =>
            {
                var localAddresses = new string[] { "127.0.0.1", "::1", ctx.Request.LocalIpAddress };
                if (localAddresses.Contains(ctx.Request.RemoteIpAddress))
                {
                    await next();
                }
            });

            //app.UseFileServer(new FileServerOptions
            //{
            //    RequestPath = new PathString("/assets"),
            //    FileSystem = new EmbeddedResourceFileSystem(typeof(AppBuilderExtensions).Assembly, "Thinktecture.IdentityManager.Core.Assets")
            //});
            //app.UseFileServer(new FileServerOptions
            //{
            //    RequestPath = new PathString("/assets/libs/fonts"),
            //    FileSystem = new EmbeddedResourceFileSystem(typeof(AppBuilderExtensions).Assembly, "Thinktecture.IdentityManager.Core.Assets.Content.fonts")
            //});
            //app.UseStageMarker(PipelineStage.MapHandler);

            //app.UseJsonWebToken();
            var resolver = AutofacConfig.Configure(config);
            WebApiConfig.Configure(app, resolver, config); 
            
            return app;
        }
    }
}
