using Application.Admins;
using Application.Authentication;
using Application.Email;
using Application.Files;
using Application.Interfaces;
using Application.INTERFACES;
using Application.Locations;
using Application.Favorites;
using Application.Notifications;
using Application.Users;
using Domain;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model.Dto;
using Model.Dto.Favorites;
using Model.Dto.Users;
using Model.Others;
using Model.Requests;
using Model.Requests.Favorites;
using Newtonsoft.Json.Serialization;
using Persistence;
using System;
using System.IO;
using System.Text;
using Model.Dto.Order;
using Model.Requests.Orders;
using Application.Orders;
using Model.Dto.Rate;
using Model.Requests.Rate;
using Application.Rates;
using Model.Dto.Rating;
using Model.Requests.Rating;
using Application.Ratings;
using Model.Dto.Vehicle;
using Model.Requests.Vehicle;
using Application.Vehicles;
using Application.VehicleTypes;

namespace SpiderJob
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
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(15);
            });
            services.AddHttpContextAccessor();
            services.AddRazorPages();

            services.AddCors(o => o.AddPolicy("MyPolicy",
                configurePolicy =>
                configurePolicy.AllowAnyOrigin()
                .AllowAnyHeader().AllowAnyMethod()));

            //Adding custom ErrorFilter
            services.AddControllers(x =>
            {
                x.Filters.Add<ErrorFilter>();
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = false;
            });

            //Swagger
            services.AddSwaggerGen(c =>
            {
                // configure SwaggerDoc and others

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                        {securityScheme, new string[] { }}
                });

                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //c.IncludeXmlComments(xmlPath);

            });



            // Entity Framework
            services.AddDbContext<eTaxiDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("Persistence")));




            // For Identity
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
                //opt.SignIn.RequireConfirmedEmail = true;
            })
                .AddSignInManager<SignInManager<ApplicationUser>>()
                .AddRoles<IdentityRole<int>>()
                .AddEntityFrameworkStores<eTaxiDbContext>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();



            //Adding Authentication 
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                //Adding JWT BEARER
                .AddJwtBearer(X =>
                {
                    X.SaveToken = true;
                    X.RequireHttpsMetadata = false;
                    X.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                    };
                })
                .AddGoogle(options =>
                {
                    options.CallbackPath = new PathString("/signin-google");
                    options.ClientId = Configuration["GoogleAuthSettings:clientId"];
                    options.ClientSecret = Configuration["GoogleAuthSettings:ClientSecret"];
                }).AddLinkedIn(options =>
                {
                    options.ClientId = Configuration["LinkedinAuthSettings:clientId"];
                    options.ClientSecret = Configuration["LinkedinAuthSettings:ClientSecret"];
                }).AddFacebook(options =>
                {
                    options.AppId = Configuration["FacebookAuthSettings:clientId"];
                    options.AppSecret = Configuration["FacebookAuthSettings:ClientSecret"];
                });
            var emailConfiguration = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            var appSetings = Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>();

            services.AddSignalR();
            services.AddSingleton(appSetings);
            services.AddSingleton(emailConfiguration);
            services.AddScoped<IEmail, Email>();
            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<ICRUD<LocationDto, LocationSearchRequest, LocationInsertRequest, LocationUpsertRequest>, Locations>();
            services.AddScoped<ICRUD<NotificationDto, NotificationSearchRequest, NotificationInsertRequest, NotificationInsertRequest>, Notifications>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<ICRUDP<UsersDto, object, object, UserUpsertRequest, UserPatchDto>, Users>();
            services.AddScoped<IUser, Users>();
            services.AddScoped<ICRUD<FileDto, FileSearchRequest, FileInsert, FileUpsert>, Files>();
            services.AddScoped<IAdmin, Admins>();
            services.AddScoped<ICRUD<FavoritesDto, FavoritesSearchRequest, FavoritesInsertRequest, FavoritesInsertRequest>, Favorites>();
            services.AddScoped<ICRUD<OrderDto, OrderSearchRequest, OrderInsertRequest, OrderUpsertRequest>, Orders>();
            services.AddScoped<ICRUD<RateDto, RateSearchRequest, RateInsertRequest, object>, Rates>();
            services.AddScoped<ICRUD<RatingDto, RatingSearchRequest, RatingInsertRequest, object>, Ratings>();
            services.AddScoped<ICRUD<VehicleDto, VehicleSearchRequest, VehicleInsertRequest, VehicleUpsertRequest>, Vehicles>();
            services.AddScoped<ICRUD<VehicleTypeDto, VehicleTypeSearchRequest, VehicleTypeInsertRequest, object>, VehicleTypes>();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("MyPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestAspCore v1"));
            app.UseSession();
            //app.UseHttpsRedirection();
            app.UseSession();

            app.UseRouting();

            //Authentication comes before Authorization.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });


            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });
            //app.UseStaticFiles(new StaticFileOptions
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
            //    RequestPath = new PathString("/Images")
            //});
        }

    }
}