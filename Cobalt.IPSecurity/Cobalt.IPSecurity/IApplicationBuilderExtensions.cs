using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Cobalt.IPSecurity
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseIPSecurity(this IApplicationBuilder target)
        {
            var assembly = typeof(IApplicationBuilderExtensions).Assembly;
            target.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new EmbeddedFileProvider(assembly, "Cobalt.IPSecurity.wwwroot")
            });

            // Maybe this should live in another method because it must be called before UseMvc
            target.Use(async (context, next) =>
            {
                var isControlPanel = context.Request.Path.StartsWithSegments(new PathString("/cp"));
                if (isControlPanel)
                {
                    context.Response.Redirect("/");
                }

                await next.Invoke();
            });

            return target;
        }
    }
}
