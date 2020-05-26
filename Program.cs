using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Hosting;

namespace TodoApi
{
    public class Program
    {
       public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    // To be fully Ev2 compatible, this should be client certificate authentication
                    /*
                    webBuilder.ConfigureKestrel(o =>
                    {
                        o.ConfigureHttpsDefaults(o =>
                    o.ClientCertificateMode =
                        ClientCertificateMode.RequireCertificate);
                    });
                    */
                });
    }
}
