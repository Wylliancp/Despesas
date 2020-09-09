using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Despesas.Domain.Handlers;
using Despesas.Domain.IRepositories;
using Despesas.Infra.Context;
using Despesas.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Despesas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnectionString")));
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("database"));

            //Repository
            services.AddTransient<IDespesaRepository, DespesaRepository>();
            services.AddTransient<IMembroFamiliarRepository, MembroFamiliarRepository>();
            //Handler
            services.AddTransient<DespesasHandler,DespesasHandler>();
            services.AddTransient<MembroFamiliarHandler,MembroFamiliarHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
