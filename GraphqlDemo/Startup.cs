using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphqlDemo.GraphQL.Schemas;
using GraphqlDemo.GraphQL.Types;
using GraphqlDemo.Repositories;
using GraphqlDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphqlDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region GraphQL

            services.AddScoped<AuthorQuery>();
            services.AddScoped<ISchema, AuthorSchema>();

            services.AddGraphQL(options => options.EnableMetrics = false)
                .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = true)
                .AddNewtonsoftJson()
                .AddDataLoader()
                .AddGraphTypes(typeof(AuthorSchema), ServiceLifetime.Scoped);

            #endregion

            #region Services

            services.AddScoped<AuthorService>();
            services.AddScoped<AuthorRepository>();

            #endregion

            services.AddControllers();
            services.AddHttpContextAccessor();

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