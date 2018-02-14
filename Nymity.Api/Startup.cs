using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nymity.Core.Infrastructure;
using Nymity.Core.Repositories;
using Swashbuckle.AspNetCore.Swagger;
using System.Data;
using System.Data.SqlClient;

namespace Nymity.Api
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
            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("webappcros",
                    policy => policy.WithOrigins("http://localhost:4200"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
            });

            services.AddScoped<IDbConnection, SqlConnection>(con =>
                new SqlConnection(Configuration.GetConnectionString("ApiData"))
            );

            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("webappcros");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseMvc();
        }
    }
}
