using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace Cobalt.Forums
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseForums(this IApplicationBuilder target)
        {
            var assembly = typeof(IApplicationBuilderExtensions).Assembly;
            target.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new EmbeddedFileProvider(assembly, "Cobalt.Forums.wwwroot")
            });
            return target;
        }
    }
}
