using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// UseNodeModules : Extension that allows to serve bootstrap content files with ASP.Core
        /// </summary>
        /// <param name="application"></param>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseNodeModules(
            this IApplicationBuilder application, string rootPath)
        {
            var path = Path.Combine(rootPath, "node_modules");
            var fileProvider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = fileProvider;

            application.UseStaticFiles(options);
            return application;
        }
    }
}
