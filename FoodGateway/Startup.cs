using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoodGateway
{
    public class Startup
    {
        public IConfiguration Config { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddEnvironmentVariables();
            Config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Config);
            services.AddSingleton<IWelcomeMessage, WelcomeMessage>();
            services.AddScoped<IIngredientData, IngredientDataInMemory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IWelcomeMessage recipe)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               app.UseExceptionHandler(new ExceptionHandlerOptions { ExceptionHandler = context => context.Response.WriteAsync("Out of order!") });
            }

            app.UseWelcomePage("/welcome");

            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseMvc(ConfigureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not Found"));
            //app.Run(async (context) =>
            //{
            //    //var message = Config["Recipe"];
            //    var recipeSelected = recipe.GetRecipe();
            //    await context.Response.WriteAsync(recipeSelected);
            //});
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
