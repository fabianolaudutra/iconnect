using ElectronNET.API;
using Iconnect.Dominio.Helpers;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Crosscutting;
using Iconnect.Portal.Helpers.HubConfigs;
using Iconnect.Portal.HubConfigs;
using Iconnect.Portal.IdentityServer;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

namespace Iconnect.Portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            staticConfig = Configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration staticConfig { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithOrigins(appSettings.WebSiteUrl);
            }));

            services.AddSignalR();

            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api - Iconnect", Version = "v1" });
            });

            services.AddDbContext<IconnectCoreContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IResourceOwnerPasswordValidator, ResourceOwnerPAsswordValidator>();
            services.AddScoped<IProfileService, ProfileService>();

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddResourceOwnerValidator<ResourceOwnerPAsswordValidator>()
                .AddProfileService<ProfileService>();

            services.AddAuthentication("Bearer").AddIdentityServerAuthentication(option =>
            {
                option.Authority = appSettings.IdentityServerUrl;
                option.RequireHttpsMetadata = false;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            RegisterServices(services, appSettings);
        }

        private void RegisterServices(IServiceCollection services, AppSettings appSettings)
        {
            Injector.RegisterServices(services, appSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IconnectCoreContext iconnectCoreContext)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Executa migrations e altera��es do banco ao executar o projeto
                //iconnectCoreContext.Database.Migrate();

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseIdentityServer();

            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
          
            app.UseEndpoints(endpoints =>
           {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
                // endpoints.MapHub<BiometriaHub>("/controleAcesso");
                // endpoints.MapHub<ControleDeAcessoHub>("/monitoramentoControleAcesso");
                // endpoints.MapHub<ConnectGuardHub>("/monitoramento");
                // endpoints.MapHub<ControleOcorrenciaHub>("/solicitarZelador");
                // endpoints.MapHub<LiberacaoAppHub>("/liberacaoApp");
                // endpoints.MapHub<ComboClienteGuardHub>("/comboClienteGuard");
           });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

               // spa.Options.SourcePath = "ClientApp";
                spa.Options.SourcePath = "ClientApp"; 

                if (env.IsDevelopment())
                {
                     spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                   // spa.UseAngularCliServer(npmScript: "start");
                }
            });

            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync());
        }
    }
}
