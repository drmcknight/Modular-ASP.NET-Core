using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Cobalt.IPSecurity
{
    public static class IMvcBuilderExtensions
    {
        public static IMvcBuilder AddIPSecurity(this IMvcBuilder target)
        {
            var assembly = typeof(IMvcBuilderExtensions).Assembly;
            target.AddApplicationPart(assembly);
            target.AddRazorOptions(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assembly, "Cobalt.IPSecurity"));
            });

            return target;
        }
    }
}
