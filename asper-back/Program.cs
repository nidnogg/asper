// using asper_back.Services;
using Microsoft.EntityFrameworkCore;
using asper_back.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => 
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://localhost");
        }
    );
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TO-DO fix GetConnectionString missing from ConfigurationRoot
// builder.Services.AddDbContext<UserContext>(options => {
//     options.UseNpgsql(ConfigurationRoot.GetConnectionString("UserContext"));
// });

var app = builder.Build();

app.UseCors(
    options => options.WithOrigins("https://localhost")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For serving via fetch
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
