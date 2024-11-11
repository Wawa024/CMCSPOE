using CMCSPOE;
using CMCSPOE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace CMCS._2
{
    public class Program
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InMemoryDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddControllersWithViews();
        }


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}