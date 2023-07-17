using ElectronNET.API;
using Iconnect.Infraestrutura.Context;
using Iconnect.Portal;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

//namespace Iconnect.Portal
//{
    var build  = WebApplication.CreateBuilder(args);
    var startup = new Startup(build.Configuration);
    startup.ConfigureServices(build.Services);
   // build.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    var context = new IconnectCoreContext();
    
    var app = build.Build();

    startup.Configure(app, app.Environment, context);

    app.Run();
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //             CreateWebHostBuilder(args).Build().Run();
    //     }

    //     public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //         WebHost.CreateDefaultBuilder(args)
    //             .UseElectron(args)
    //             .UseStartup<Startup>();
    // }
//}
