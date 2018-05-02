using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Cobalt.Forums
{
    public static class IMvcBuilderExtension
    {
        public static IMvcBuilder AddForums(this IMvcBuilder target)
        {
            var assembly = typeof(IMvcBuilderExtension).Assembly;
            target.AddApplicationPart(assembly);
            target.AddRazorOptions(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(assembly, "Cobalt.Forums"));
            });

            return target;
        }
    }
}
