using SalesOrder.IOC;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServiceInstance(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSites",
        builder =>
        {
            builder.AllowAnyMethod()
               .AllowAnyHeader().AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowSites");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
