using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Persistence
{
    public class SeedData
    {
        public static void main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services=scope.ServiceProvider;
                try
                {
                    SeedDataBase.Initialize(services);
                }
                catch (Exception ex)

                {
                    var logger = services.getRequiredService<ILogger<Program>>();
                    logger.logError(ex, "an errir occured seeding the Db");
                }
            }
            host.Run();
        }
    }
}
