using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentHousing.Data;
using StudentHousing.Identity;
using StudentHousing.Services;

namespace StudentHousing
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
            services.AddMvc();
            //Listing Database
            services.AddDbContext<ListingDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("StudentHousing")));
            services.AddScoped<IDataService, ListingDataService>();


            //Identity Stuff
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddDbContext<StudentHousingUserDBContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("UserIdentity"),
                sql => sql.MigrationsAssembly(migrationAssembly)));

            services.AddIdentity<StudentHousingUser, IdentityRole>(options => { }).
                AddEntityFrameworkStores<StudentHousingUserDBContext>();


            //services.AddScoped<IUserStore<StudentHousingUser>, UserOnlyStore<StudentHousingUser, StudentHousingUserDBContext>>();
            services.AddScoped<IUserClaimsPrincipalFactory<StudentHousingUser>,
            StudentHousingUserClaimsPrincipalFactory>();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Listing}/{action=Index}/{id?}");
            });
        }
    }
}
