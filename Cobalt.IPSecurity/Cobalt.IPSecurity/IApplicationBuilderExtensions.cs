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

            return target;
        }

        /// <summary>
        /// This has to run before UseMvc
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCPProtection(this IApplicationBuilder target)
        {
            target.Use(async (context, next) =>
            {
                // This is just a dumb example
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
