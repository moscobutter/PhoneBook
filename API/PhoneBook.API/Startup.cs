using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.DL.Interfaces;
using PhoneBook.DL;
using PhoneBook.BL.Services;
using PhoneBook.BL.Interfaces;
using Microsoft.EntityFrameworkCore;
using PhoneBook.ML;
using AutoMapper;
using PhoneBook.API.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace PhoneBook.API
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var appSettingConfig = Configuration.GetSection("AppSettings");
            services.Configure<Configs.AppSettings>(appSettingConfig);
            var appSettings = appSettingConfig.Get<Configs.AppSettings>();
            var secutiryKey = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(auth =>
           {
               auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
               auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           }).AddJwtBearer( bearer =>
           {
               bearer.RequireHttpsMetadata = false;
               bearer.SaveToken = true;
               bearer.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(secutiryKey)
               };
           });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(Configuration.GetConnectionString("DbConnection"));
            });

            services.AddIdentity<User, Role>().AddEntityFrameworkStores<DatabaseContext>();

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();

            services.AddScoped<IPhoneBookService, PhoneBookService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PhoneBookProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ISeedData, SeedData>();

            
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseAuthentication();
            //app.UseIdentity();
            app.UseMvc();
        }
    }
}
