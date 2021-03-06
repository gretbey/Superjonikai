using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleInjector;
using Superjonikai.DB.SQLRepository;
using Superjonikai.Model.Repository;
using System;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Superjonikai.Model.ActionFilters;
using Superjonikai.Model.Services;

namespace Superjonikai.UI
{
    public class Startup
    {
        
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            container.Options.ResolveUnregisteredConcreteTypes = false;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "Server=localhost;Database=FlowersDB;Password=root;User=root";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
            //services.AddScoped<IAuthorizationHandler, AuthorizationHandler>();
            //services.AddScoped<IAuthTokenService, AuthTokenService>();
            //services.AddScoped<ITokenRepository, TokenSqlRepository>();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("Token", policy =>
            //        policy.Requirements.Add(new AuthTokenRequirement()));
            //});

            services.AddMvc(config =>
            {
                //config.Filters.Add(new AuthorizeFilter("Token"));
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddLogging();
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation();

                options.AddLogging();
                options.AddLocalization();
            });


            services.AddDbContext<Superjonikai.DB.DBContext>(options => options
                .UseLazyLoadingProxies()
                .UseMySql(Configuration.GetConnectionString("DefaultConnection"), serverVersion));

            if (Convert.ToBoolean(Configuration.GetSection("LoggingEnabled").Value))
            {
                services.AddMvc(opts =>
                {
                    opts.Filters.Add(new LogActionFilter());
                });
            }

            InitializeContainer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            container.Verify();
        }

        private void InitializeContainer()
        {
            string repositoryPluginPath = Configuration.GetSection("Plugins").GetValue<string>("RepositoriesDllPath");
            string servicePluginPath = Configuration.GetSection("Plugins").GetValue<string>("ServicesDllPath");

            string[] pluginsDirectories = { servicePluginPath, repositoryPluginPath };

            Model.ObjectContainer.InitializeContainer(container, pluginsDirectories);

            InjectRepositories(repositoryPluginPath);

        }

        private void InjectRepositories(string path)
        {
            if(path == "")
            {
                container.Register<IFlowerRepository, FlowerSqlRepository>(Lifestyle.Scoped);
                container.Register<IBouquetRepository, BouquetSqlRepository>(Lifestyle.Scoped);
                container.Register<IOrderRepository, OrderSqlRepository>(Lifestyle.Scoped);
                container.Register<IGiftCardRepository, GiftCardSqlRepository>(Lifestyle.Scoped);
                container.Register<IBouquetOrderRepository, BouquetOrderSqlRepository>(Lifestyle.Scoped);
                container.Register<IFlowerOrderRepository, FlowerOrderSqlRepository>(Lifestyle.Scoped);
                container.Register<IUserRepository, UserSqlRepository>(Lifestyle.Scoped);
                container.Register<ITokenRepository, TokenSqlRepository>(Lifestyle.Scoped);
            }
        }
    }
}
