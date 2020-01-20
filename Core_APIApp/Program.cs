using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core_APIApp
{
    /// <summary>
    /// Entrypoint
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// IWebHostBuilder --> Contract that represents dotnet.exe on Host machine
        /// Strats the Web Application hosting  under dotnet.exe
        /// WebHost: The HttpChannnel for Http Request Processing
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>(); // instantiate the Startup Class and inject
                                // IConfiguration interface and IServiceCollection interface
    }
}
