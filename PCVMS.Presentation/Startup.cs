using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PCVM.Web.Helpers;
using PCVM.Web.Mapping;
using PCVMS.Presentation.Helpers;

namespace PCVMS.Presentation
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
            services.AddRazorPages();
            services.AddMemoryCache();


            services.AddHttpContextAccessor();


            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(ActionFilter));
            });
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new SampleProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<ICacheHelper, CacheHelper>(); ;

            //services services.AddAutoMapper();
            //  services.AddAutoMapper();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            // services.AddMvc().AddRazorOptions(options => options.AllowRecompilingViewsOnFileChange = true);
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()

                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // Create the container builder.
         



            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);


            var appSettings = appSettingsSection.Get<AppSettings>();

            //var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = true;
            //    // x.Authority = "http://localhost:5000/API/Authenticate/Authenticate";
            //    x.TokenValidationParameters = new TokenValidationParameters
            //    {

            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false
            //    };
            //});



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(

                options => {
                 //   options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = SameSiteMode.Lax;
                    options.LoginPath = "/Login/Index";
                    options.LogoutPath = "/Login/Logout";
                    options.Cookie.Name = "AuthCookieAspNetCore";
                }
                );
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)

            //  .AddCookie(options =>
            //  {
            //      options.Cookie.HttpOnly = true;
            //      //options.Cookie.SecurePolicy =  _environment.IsDevelopment()
            //      //  ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            //      options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

            //      options.Cookie.SameSite = SameSiteMode.Lax;
            //      options.Cookie.Name = "SimpleTalk.AuthCookieAspNetCore";
            //      options.LoginPath = "/Login/Index";
            //      options.LogoutPath = "/Login/Logout";

            //  });
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    options.MinimumSameSitePolicy = SameSiteMode.Strict;
            //    options.HttpOnly = HttpOnlyPolicy.None;
            //    options.Secure = CookieSecurePolicy.None;


            //});


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
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var supportedCultures = new[]
     {

                new CultureInfo("en"),
                new CultureInfo("en-US"),
                new CultureInfo("ar"),
                new CultureInfo("ar-OM"),

            };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("ar"),
            // Formatting numbers, dates, etc.
            SupportedCultures = supportedCultures,
            // UI strings that we have localized.
            SupportedUICultures = supportedCultures
        });

        // app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        app.UseCors(option => option
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();
            app.UsePathBase("/webTest");
            app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=login}/{action=Index}/{id?}");
        });
    }
    }
}
