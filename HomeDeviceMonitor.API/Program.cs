var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
    options.AddPolicy(name: "TmpForAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin();
        })
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
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
builder.Services.AddHealthChecks();

var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseHealthChecks("/hc");
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
