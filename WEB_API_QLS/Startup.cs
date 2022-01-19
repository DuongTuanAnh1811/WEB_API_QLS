using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API_QLS.Application.Interfaces;
using WEB_API_QLS.Domain.Entities;
using WEB_API_QLS.Domain.Repositories;
using WEB_API_QLS.Helper;
using WEB_API_QLS.Infrastructure.Context;

namespace WEB_API_QLS
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
            services.AddControllers().AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<quanlysachContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QLS")));
            services.AddTransient<IQuequanRepository, QuequanRepository>();
            services.AddTransient<IBandocRepository, BandocRepository>();
            services.AddTransient<ITaikhoanRepository, TaikhoanRepository>();
            services.AddTransient<INhanvienRepository, NhanvienRepository>();
            services.AddTransient<ITheloaiRepository, TheloaiRepository>();
            services.AddTransient<ISachRepository, SachRepository>();
            services.AddTransient<INgaymuonRepository, NgaymuonRepository>();
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>()); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
