using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDET.Transversal.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using CIDET.Transversal.Common;
using CIDET.Transversal.Logging;
using CIDET.Application.Interface;
using CIDET.Application.Main;
using CIDET.Domain.Interface;
using CIDET.Domain.Core;
using CIDET.InfraStructure.Interface;
using CIDET.InfraStructure.Repository;
using CIDET.InfraStructure.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CIDET.InfraStructure.DAL;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using CIDET.Application.DTO;
using CIDET.Services.WebAPIRest.Validator;

namespace CIDET.Services.WebAPIRest
{
    public class Startup
    {
        readonly string MiCors = "MiCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<CIDETDataContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("MyStringConnection"))
            //.EnableSensitiveDataLogging(true)
            //.UseLoggerFactory(MyLoggerFactory)
            //);

            services.AddDbContext<CIDETDataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"),
                    assembly => assembly.MigrationsAssembly(typeof(CIDETDataContext).Assembly.FullName));
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            
            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: this.MiCors, builder =>
                {
                    builder.WithHeaders("*");
                    builder.WithOrigins("*");
                    builder.WithMethods("*");
                });
            });

            //Devolver el JSON tal cual como est� el modelo
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });

            #region Inyectando Capas

            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            services.AddScoped<IMunicipiosApplication, MunicipiosApplication>();
            services.AddScoped<IMunicipiosDomain, MunicipiosDomain>();
            services.AddScoped<IMunicipiosRepository, MunicipiosRepository>();

            services.AddScoped<IDepartamentosApplication, DepartamentosApplication>();
            services.AddScoped<IDepartamentosDomain, DepartamentosDomain>();
            services.AddScoped<IDepartamentosRepository, DepartamentosRepository>();

            #endregion
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //jwt
            var appSettings = appSettingsSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(d =>
            {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            services.AddTransient<IValidator<MunicipioDTO>, MunicipioDTOValidator>();
            services.AddTransient<IValidator<DepartamentoDTO>, DepartamentoDTOValidator>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(this.MiCors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });
    }
}
