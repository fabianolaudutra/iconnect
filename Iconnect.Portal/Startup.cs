using AutoMapper;
using ElectronNET.API;
using Iconnect.Dominio.Helpers;
using Iconnect.Infraestrutura.Context;
using Iconnect.Infraestrutura.Crosscutting;
using Iconnect.Portal.Helpers;
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           // services.AddAutoMapper(typeof(Startup));

            // Auto Mapper Configurations
            // var mapperConfig = new MapperConfiguration(mc =>
            // {
            //     mc.AddProfile(new MappingProfiles());
            // });

            // IMapper mapper = mapperConfig.CreateMapper();
            // services.AddSingleton(mapper);

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

            
            services.AddDbContext<IconnectCoreContext>((options)=>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
            });
            
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

            services.AddControllers();

        }

        private void RegisterServices(IServiceCollection services, AppSettings appSettings)
        {
            Injector.RegisterServices(services, appSettings);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(WebApplication app, IWebHostEnvironment env ,  IconnectCoreContext iconnectCoreContext )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }
              else
            {
                //Executa migrations e altera��es do banco ao executar o projeto
                //iconnectCoreContext.Database.Migrate();

                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
          

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Iconnect.Portal v1");
            });

            app.UseHttpsRedirection();
            app.UseIdentityServer();

            app.UseCors("CorsPolicy");

            app.UseRouting();
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");
                
            app.MapFallbackToFile("index.html"); 


        }
    }
