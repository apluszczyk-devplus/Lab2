using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Lab2.Middlewares;
using Lab2.Data;
using Microsoft.EntityFrameworkCore;

namespace Lab2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MvcContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcContext")));

            services.AddLocalization(options =>
            {
                options.ResourcesPath = "Resources";
            });
            
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture("en-Us");
                options.AddSupportedUICultures("en-US", "de-DE", "pl-PL", "it-IT");
                options.FallBackToParentUICultures = true;

                options
                    .RequestCultureProviders
                    .Remove(typeof(AcceptLanguageHeaderRequestCultureProvider));
            });
            
            services
                .AddRazorPages()
                .AddViewLocalization();

            services.AddMvc().AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResource));
            });

            services.AddScoped<RequestLocalizationCookiesMiddleware>();
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
            app.UseStaticFiles();
            app.UseRequestLocalization();

            // will remember to write the cookie 
            app.UseRequestLocalizationCookies();
            
            app.UseRouting();
            app.UseAuthorization();

            //app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}