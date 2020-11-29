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
using SpeedrunAppBack.Models;
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
                c.SchemaFilter<EnumSchemaFilter>();
            });
            services.AddRefitClient<ISpeedrunRefit>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://www.speedrun.com"));

            services.AddHttpClient("speedrun_site", client => client.BaseAddress = new Uri("https://www.speedrun.com"));
            services.AddAutoMapper(typeof(BaseProfile).Assembly);
            services.AddScoped<IGamesApi, GamesService>();
            services.AddScoped<IStreamsApi, StreamsService>();
            services.AddMemoryCache();


            services.AddDbContext<SpeedrunDbContext>(o => o.UseNpgsql(Configuration.GetConnectionString("PostgresDB")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceScopeFactory scopefac)
        {
            using (var scope = scopefac.CreateScope())
            {
                var gs = scope.ServiceProvider.GetRequiredService<SpeedrunDbContext>();
                try
                {
                    gs.Database.Migrate();
                    var defaultModerator = gs.GameCategoryModerators.Where(g => g.GameId == "mc" && g.CategoryId == "mkeyl926" && g.UserId == "73739616").SingleOrDefault();
                    if (defaultModerator == null)
                    {
                        var user = gs.Users.Where(u => u.Id == "73739616").SingleOrDefault();
                        if (user == null)
                        {
                            gs.Users.Add(new UserModel { Id = "73739616" });
                            gs.SaveChanges();
                        }
                        defaultModerator = new GameCategoryModerator { GameId = "mc", CategoryId = "mkeyl926", UserId = "73739616" };
                        gs.GameCategoryModerators.Add(defaultModerator);
                        gs.SaveChanges();
                    }
                    var defaultMessages = gs.PulseMessages.Where(g => g.GameId == "mc").Any();
                    if (!defaultMessages)
                    {
                        gs.PulseMessages.Add(new PulseMessage { GameId = "mc", UserId = "73739616", Message = "Hello, pulse", SendTime = DateTimeOffset.UtcNow });
                        gs.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Message);
                }
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
            app.Use(async (HttpContext c, Func<Task> n) =>
            {
                if (!c.Request.Headers.TryGetValue("userid", out var userId))
                {
                    await n();
                    return;
                }
                var db = c.RequestServices.GetRequiredService<SpeedrunDbContext>();
                var existing = await db.Users.Where(u => u.Id == userId.ToString()).SingleOrDefaultAsync();
                if (existing == null)
                {
                    db.Users.Add(new UserModel { Id = userId });
                    await db.SaveChangesAsync();
                }
                await n();
            });
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
        }
    }
}
