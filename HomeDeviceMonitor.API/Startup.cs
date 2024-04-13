using HomeDeviceMonitor.API.Service;
using HomeDeviceMonitor.Application;
using HomeDeviceMonitor.Application.Common.Interfaces;
using HomeDeviceMonitor.Infrastructure;
using HomeDeviceMonitor.Persistance;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using Serilog;


namespace HomeDeviceMonitor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001";
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateAudience = false,
                    };
                });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                            TokenUrl = new Uri("https://localhost:5001/connect/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                {"api1", "Full access" },
                                {"user", "User info" },
                                {"openid", "openid" },
                            }
                        }
                    }
                });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "HomeDeviceMonitor",
                    Version = "v1",
                    Description = "Home appliance tracking and monitoring system",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Adam P",
                        Email = "a01p05@gmail.com"
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, "HomeDeviceMonitor.xml");
                c.IncludeXmlComments(filePath);
            });

            //services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHealthChecks();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1", "openid");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHealthChecks("/hc");
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeDeviceMonitor");
                c.OAuthClientId("swagger");
                c.OAuthClientSecret("secret");
                c.OAuth2RedirectUrl("https://localhost:7207/swagger/oauth2-redirect.html");
                //c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                c.OAuthUsePkce();
            });
        
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors();

            //app.MapControllers();

 
     /*       if (Environment.IsEnvironment("Test"))
            {
                app.UseIdentityServer();
            }*/
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope");
            });
        }
    }
}
