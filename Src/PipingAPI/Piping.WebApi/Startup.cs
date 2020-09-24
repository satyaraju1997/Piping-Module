using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Piping.Contracts.Repository;
using Piping.Contracts.Services;
using Piping.Repository;
using Piping.Services;
using Serilog;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Reflection;
using System.IO;
using System;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;
using Piping.Mappers;
using Piping.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Piping.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddControllers(config =>
            {
                config.Filters.Add<SessionFilter>();
            }).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);


            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("*")
                                    .AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());
            });

            services.AddMvc();

            //services.AddAuthentication(option =>
            //{
            //    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = false,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["JwtToken:Issuer"],
            //        ValidAudience = Configuration["JwtToken:Issuer"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtToken:SecretKey"]))
            //    };
            //});

            
            //services.Configure<IdentityOptions>(options =>
            //{
            //    // Default Password settings.
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequiredUniqueChars = 1;
            //});

            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtToken:SecretKey").Value);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSession(options => {
                options.IdleTimeout = System.TimeSpan.FromMinutes(2);                
            });
            var connString = Configuration.GetSection("ConnectionStrings").GetSection("PipingConnection").Value;
            services.AddEntityFrameworkNpgsql().AddDbContextPool<PipingContext>(o => o.UseNpgsql(connString));

            services.AddScoped(typeof(SessionFilter));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPlantService, PlantService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPipeMasterService, PipeMasterService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IPOFICService, POFICService>();
            services.AddScoped<IPOFECService, POFECService>();
            services.AddScoped<IPOFSCCService, POFSCCService>();
            services.AddScoped<IPOFODMService, POFODMService>();
            services.AddScoped<IStructuralMinThkService, StructuralMinThkService>();
            services.AddScoped<IInsulationTypeService, InsulationTypeService>();
            services.AddScoped<IMaterialCodesService, MaterialCodesService>();
            services.AddScoped<IMaterialMasterService, MaterialMasterService>();
            services.AddScoped<IPipeReportService, PipeReportService>();
            services.AddScoped<IInspectionStrategyService, InspectionStrategyService>();
            services.AddScoped<ICorrosionStudyService, CorrosionStudyService>();
            services.AddScoped<IRiskAnalysisService, RiskAnalysisService>();

            services.AddCors(o => o.AddPolicy("TempCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PIPING API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                     new OpenApiSecurityScheme { Reference = new OpenApiReference  { Type = ReferenceType.SecurityScheme, Id = "Bearer" } },
                     new string[] { }
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
            
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

          //  services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {

                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PIPING API V1");
                options.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerfactory.AddSerilog();


            app.UseSession();
           
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Uploads")),
            //    RequestPath = new PathString("/Uploads")
            //});

            app.UseRouting();

            app.UseCors("TempCorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapControllers();
            });


        }
    }
}
