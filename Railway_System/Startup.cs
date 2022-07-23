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
using RailwaySystem.API.Data;
using RailwaySystem.API.Repository;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API
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
            services.AddDbContext<TrainDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddTransient<ITrain, TrainRepo>();
            services.AddTransient<TrainS, TrainS>();
            services.AddTransient<ITicket, TicketRepo>();
            services.AddTransient<TicketS, TicketS>();
            services.AddTransient<IQuota, QuotaRepo>();
            services.AddTransient<QuotaS, QuotaS>();
            services.AddTransient<IStation, StationRepo>();
            services.AddTransient<StationS, StationS>();
            services.AddTransient<IBooking, BookingRepo>();
            services.AddTransient<BookingS, BookingS>();
            services.AddTransient<IUser, UserRepo>();
            services.AddTransient<UserS, UserS>();
            services.AddTransient<IBankCred, BankCredRepo>();
            services.AddTransient<BankCredS, BankCredS>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Railway_System", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Railway_System v1"));
            }

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
