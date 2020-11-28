using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Data;
using Web.Formatting;
using Web.Services;

namespace Web
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
                c.EnableAnnotations();
            });
            services.AddRefitClient<ISpeedrunRefit>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://www.speedrun.com"));

            services.AddHttpClient("speedrun_site", client => client.BaseAddress = new Uri("https://www.speedrun.com"));
            services.AddAutoMapper(typeof(BaseProfile).Assembly);
            services.AddScoped<IGamesApi, GamesService>();
            services.AddScoped<IStreamsApi, StreamsService>();

            services.AddDbContext<SpeedrunDbContext>(o => o.UseInMemoryDatabase("IN_MEMORY"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory scopefac)
        {
            using (var scope = scopefac.CreateScope())
            {
                var gs = scope.ServiceProvider.GetRequiredService<SpeedrunDbContext>();
                gs.GameCategoryModerators.Add(new GameCategoryModerator { GameId = "mc", CategoryId = "mkeyl926", UserId= "73739616" });
                gs.SaveChanges();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "Web v1"));
            }

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.Use((HttpContext c, Func<Task> n) =>
            {
                Console.WriteLine(JsonSerializer.Serialize(c.Request.Headers));
                return n();
            });
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
