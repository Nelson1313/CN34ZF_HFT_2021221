using CN34ZF_HFT_2021221.Data;
using CN34ZF_HFT_2021221.Logic;
using CN34ZF_HFT_2021221.Repository;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CN34ZF_HFT_2021221.Endpoint
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ITeamLogic, TeamLogic>();
            services.AddTransient<ILeagueLogic, LeagueLogic>();
            services.AddTransient<ICountryLogic, CountryLogic>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<TeamsDbContext, TeamsDbContext>();
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
                endpoints.MapControllers();
            });
        }
    }
}
