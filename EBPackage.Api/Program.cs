using EBPackage.Infrastructure.Interfaces;
using EBPackage.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IPackageService, PackageService>();


var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.Run();
