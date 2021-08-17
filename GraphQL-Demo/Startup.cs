using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.Types;

using GraphQL.Server;

using GraphQL_Demo.Models;
using GraphQL_Demo.Repository;
using GraphQL_Demo.Schemas;
using GraphQL_Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQL_Demo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDependencyResolver>(
                _ => new FuncDependencyResolver(_.GetRequiredService)
                );
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();
            services.AddScoped<AuthorService>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<AuthorQuery>();
            services.AddScoped<AuthorType>();
            services.AddScoped<BlogPostType>();
            services.AddScoped<ISchema, GraphQLDemoSchema>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphiQl("/graphql");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
