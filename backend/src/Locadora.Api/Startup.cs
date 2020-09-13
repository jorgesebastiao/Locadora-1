using AutoMapper;

using Locadora.Application.Features.Customers;
using Locadora.Application.Features.Genres;
using Locadora.Application.Features.Movies;
using Locadora.Application.Features.Rents;
using Locadora.Domain.Features.Customers;
using Locadora.Domain.Features.Genres;
using Locadora.Domain.Features.Movies;
using Locadora.Domain.Features.Rents;
using Locadora.Domain.Utils;
using Locadora.Infra.Data;
using Locadora.Infra.Data.Contexts;
using Locadora.Infra.Data.Features.Customers;
using Locadora.Infra.Data.Features.Movies;
using Locadora.Infra.Data.Features.Rents;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Locadora.Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IRentService, RentService>();
            services.AddTransient<IRentRepository, RentRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddDbContext<RentalContext>(options => 
            {
                options.UseSqlServer(configuration.GetConnectionString(SettingsDefinitions.RentalDatabase));
            });
            services.AddTransient(sp => new SqlConnection(configuration.GetConnectionString(SettingsDefinitions.RentalDatabase)));
            services.AddAutoMapper(typeof(GenreProfile));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
