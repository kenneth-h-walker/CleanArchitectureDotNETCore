using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookstoreIoC.Core.Interfaces;
using BookstoreIoC.Infrastructure.Data.EfBookstore;
using Microsoft.EntityFrameworkCore;
using BookstoreIoC.Factory;
using BookstoreIoC.Core;

namespace BookstoreIoC.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            GlobalVars.Instance.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<BookstoreContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options => options.Conventions.AddPageRoute("/Authors/Index",""));

            // Register application services
            string bookstoreDataAccess = Configuration.GetValue<string>("BookstoreDataAccess");
            if (bookstoreDataAccess == "EntityFramework")
                services.AddSingleton<IBookstoreDacFactory>(new EfBookstoreDacFactory());
            else if (bookstoreDataAccess == "Dapper")
                services.AddSingleton<IBookstoreDacFactory>(new DapperBookstoreDacFactory());
            else { throw new ArgumentException($"Improper BookstoreDataAccess configuration setting {bookstoreDataAccess}"); }
            services.AddScoped<IAuthorRepository>(provider =>
            {
                return provider.GetRequiredService<IBookstoreDacFactory>().CreateAuthorRepository();
            });
            //services.AddScoped<IAuthorRepository, AuthorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
