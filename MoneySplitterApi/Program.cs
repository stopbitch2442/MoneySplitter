using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MoneySplitterApi;
using MoneySplitterApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Money Splitter API",
        Version = "v1",
        Description = "A simple web API for splitting money among friends.",
        Contact = new OpenApiContact
        {
            Name = "Timur",
            Email = "asap@fuckpolice.cum"
        },
        License = new OpenApiLicense
        {
            Name = "MIT License",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });
});

// Add Entity Framework Core migrations middleware
var app = builder.Build();
app.UseMigration();
app.UseRouting();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Добавленный middleware
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Money Splitter API V1");
    });
}

app.Run();