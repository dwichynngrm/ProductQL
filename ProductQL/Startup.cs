using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductQL.GraphQL;
using ProductQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<ProductQLContext>(options => options.UseSqlServer(connString));

            services
                .AddGraphQLServer()
                .AddDocumentFromFile("GraphQL/mygraph.graphql")
                .BindRuntimeType<Query>()
                .BindRuntimeType<Mutation>()
                .BindRuntimeType<AddUserInput>()
                .BindRuntimeType<AddUserPayload>()
                .BindRuntimeType<AddProductInput>()
                .BindRuntimeType<AddProductPayload>();
;

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapGet("/", async context =>
                {
                   await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
