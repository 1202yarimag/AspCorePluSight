using System;
using System.Diagnostics;
using AspCorePluSight.Data;
using AspCorePluSight.Middleware;
using AspCorePluSight.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspCorePluSight
{
    public class Startup
    {
        private IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddOpenIdConnect(options => {

                _configuration.Bind("AzureAd", options);
            }).AddCookie();
            services.AddSingleton<IGreeter, Greeter>();
            //services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB;
                                                          Initial Catalog = OdeToFood; Integrated Security = True; MultipleActiveResultSets=True"));
            services.AddScoped<IRestaurantData, SqlRestaurantData>();
            services.AddScoped<IAuto, InMemoryAutoData>();
            services.AddMvc();
            services.AddLogging();
            services.AddDistributedRedisCache(option => {
                option.Configuration = @"https://localhost:44358";
                option.InstanceName = @"master";
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

            //    app.Run(async (context) =>
        //    {
        //        var greeting = configuration["Greeting"];
        //        await context.Response.WriteAsync(greeting);
        //    });
        //}
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter,ILogger<Startup> logger, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
            //app.UseDeveloperExceptionPage();
            //}
            //app.Use(next =>
            //{
            //    return async context =>
            //    {

            //        logger.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }

            //    };

            //    });
            loggerFactory
        .AddDebug();

            // add Trace Source logging
            var testSwitch = new SourceSwitch("sourceSwitch", "Logging Sample");
            testSwitch.Level = SourceLevels.All;
            loggerFactory.AddTraceSource(testSwitch,
                new TextWriterTraceListener(writer: Console.Out));

            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            app.UseStaticFiles();
            app.UseNodeModules(env.ContentRootPath);

            app.UseAuthentication();
            //app.UseMvcWithDefaultRoute();
            //app.UseMvc();   //It can't find the route.
            app.UseMvc(ConfigureRoutes);
            //app.UseDefaultFiles();
            //app.UseFileServer();
            app.UseCookiePolicy();
            app.Run(async (context) =>
            {
                //throw new Exception("Hata!!!");
                var greeting = greeter.GetMessage();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");
             
                //await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
     name: "default_route",
     template: "{controller}/{action}/{id?}",
     defaults: new { controller = "Home", action = "Index" });

          
        }
    }
}
 