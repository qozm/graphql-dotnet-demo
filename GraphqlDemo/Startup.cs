using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphqlDemo.Ef;
using GraphqlDemo.GraphQL.Schemas;
using GraphqlDemo.GraphQL.Types;
using GraphqlDemo.Repositories;
using GraphqlDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphqlDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region GraphQL

            services.AddScoped<RootQuery>();
            services.AddScoped<ISchema, RootSchema>();

            services.AddGraphQL(options => options.EnableMetrics = false)
                .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
                .AddNewtonsoftJson()
                .AddDataLoader()
                .AddGraphTypes(typeof(RootSchema), ServiceLifetime.Scoped);

            #endregion

            #region Services

            services.AddScoped<AuthorService>();
            services.AddScoped<AuthorRepository>();

            #endregion

            services.AddControllers();
            services.AddHttpContextAccessor();

            //services.AddPooledDbContextFactory<WikiContext>(options =>
            //{
            //    options.EnableSensitiveDataLogging(true);
            //    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            //});
            //services.AddDbContext<WikiContext>(options =>
            //{
            //    //options.UseSqlite(Configuration.GetConnectionString("DefaultSQLiteConnection")
            //    options.UseSqlite(@"Data Source=Data/wiki.db");
            //});
            //services.AddEntityFrameworkSqlite().AddDbContext<WikiContext>();
            //services.AddDbContext<WikiContext>(options =>
            //{
            //    options.UseSqlite(@"Data Source=Data/wiki.db");
            //},
            //contextLifetime: ServiceLifetime.Transient,
            //optionsLifetime: ServiceLifetime.Singleton
            //);

            //services.AddPooledDbContextFactory<WikiContext>(options =>
            //{
            //    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //    options.UseSqlite(@"Data Source=Data/wiki.db")
            //    .EnableServiceProviderCaching(false);
            //}, poolSize: 32);

            //services.AddDbContext<WikiContext>(options =>
            //{
            //    options.UseSqlite(@"Data Source=Data/wiki.db");
            //}
            //,contextLifetime: ServiceLifetime.Scoped
            //,optionsLifetime: ServiceLifetime.Singleton
            //);

            //services.AddPooledDbContextFactory<WikiContext>(options =>
            //{
            //    options.UseSqlite(@"Data Source=Data/wiki.db");
            //});

            //services.AddEntityFrameworkSqlite().AddDbContext<WikiContext>();

            services.AddDbContext<WikiContext>(options =>
            {
                options.UseSqlite(@"Data Source=Data/wiki.db");
            });

            services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseGraphQL<ISchema>();

            app.UseGraphQLPlayground(new PlaygroundOptions
            {
                EditorTheme = EditorTheme.Light,
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}