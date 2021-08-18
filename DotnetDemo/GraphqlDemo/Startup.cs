using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphiQl;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using GraphqlDemo.Controllers;
using GraphqlDemo.GraphQL.Schemas;
using GraphqlDemo.GraphQL.Types;
using GraphqlDemo.Repository;
using GraphqlDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GraphqlDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISchema, AuthorSchema>(
                services =>
                    new AuthorSchema(new SelfActivatingServiceProvider(services))
            );


            //services.AddScoped<IDependencyResolver>(_ => new FuncDependencyResolver(_.GetRequiredService));
            //services.AddScoped<IServiceProvider>(_ => new IServiceProvider(_.GetRequiredService));
            //services.AddScoped<IServiceProvider>(_ => _);

            //services.AddGraphQL();

            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<AuthorService>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<AuthorQuery>();
            services.AddScoped<AuthorType>();
            services.AddScoped<BlogPostType>();
            services.AddScoped<ISchema, AuthorSchema>();
            services.AddScoped<GraphQLController>();

            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseGraphiQl("/graphql");
        }
    }
}