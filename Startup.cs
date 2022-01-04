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

using Microsoft.EntityFrameworkCore;
using COSMIDENT.Models;
using COSMIDENT.Data;
using COSMIDENT.Interfaces;
using COSMIDENT.Repositories;
using COSMIDENT.Settings;
using COSMIDENT.Services;
using Hangfire;
using Hangfire.MemoryStorage;


namespace COSMIDENT
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
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            services.AddControllersWithViews();
            services.AddScoped<IUnit, UnitRepository>();
            services.AddScoped<ISupplier, SupplierRepository>();

            services.AddCors(c => 
            { c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()); 
            });

            // Connection
            // services.AddDbContext<InventoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbconn")));
            services.AddDbContext<InventoryContext>(options => options.UseSqlServer(Configuration.GetConnectionString("dbconn")));

            //Hangfire
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage());

            services.AddHangfireServer();

            services.AddSingleton<IPrintJob, PrintJob>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider)
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //Hangfire
            app.UseHangfireDashboard();
            backgroundJobClient.Enqueue(() => System.Diagnostics.Debug.WriteLine("Hello hangfire job"));
            //recurringJobManager.AddOrUpdate(
                //"Run every minute",
                //() => serviceProvider.GetService<IPrintJob>().Print(),
               // "* * * * * *"
                //);

            //Elke minuut bericht - printjob.cs - Dagelijks = Minutely vervangen door Daily
            RecurringJob.AddOrUpdate("easyjob", () => serviceProvider.GetService<IPrintJob>().Print(), Cron.Minutely);
        }
    }
}
