using GitHubActionsDemo.Service.Infrastructure;
using GitHubActionsDemo.Persistance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

// DI
builder.Services.AddServiceDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    await app.InitDatabase();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
