using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CovidInfo.Services.Interfaces;
using CovidInfo.Services.Implementation;
using Microsoft.AspNetCore.Http;
using CovidInfo.Data.Implementation;

namespace CovidInfo
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
            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddHttpClient<ICovidService, CovidService>(client =>
            {
                client.BaseAddress = new Uri("https://covid19-brazil-api.now.sh/api/report/v1/brazil/uf/sp");
            });

            services.AddPushSubscriptionStore(Configuration)
                .AddPushNotificationService(Configuration);

            // services.AddSingleton<ICovidService, CovidService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
           app.UseStaticFiles(new StaticFileOptions(){
                OnPrepareResponse = (context) => {
                    var header = context.Context.Response.GetTypedHeaders();

                    header.CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue(){
                        Public = true,
                        MaxAge = TimeSpan.FromDays(30)
                    };
                }
            });

            
            app.UseRouting();

            app.UseAuthorization();

             using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                PushSubscriptionContext context = serviceScope.ServiceProvider.GetService<PushSubscriptionContext>();
                context.Database.EnsureCreated();
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
