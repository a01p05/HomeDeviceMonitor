using HomeDeviceMonitor.Application;
using HomeDeviceMonitor.Infrastructure;
using HomeDeviceMonitor.Persistance;
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
            services.AddCors(options =>
            {
                options.AddPolicy("TmpForAllOrigins", policy => policy.AllowAnyOrigin());
            });
            services.AddApplication();
            services.AddInfrastructure(Configuration);
            services.AddPersistance(Configuration);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
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
            app.UseSwaggerUI();
        
            app.UseHttpsRedirection();
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
                endpoints.MapControllers();
            });
        }
    }
}
