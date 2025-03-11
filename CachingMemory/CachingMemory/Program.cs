using CachingMemory.Repositories;
using CachingMemory.Repositories.Cache.Memory;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<ICacheMemory, CacheMemory>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "Caching Memory API"); });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

