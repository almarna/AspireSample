using DotnetAspire.DbUp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

await Task.Delay(10000);

var builder = Host.CreateApplicationBuilder(args);

builder.AddSqlServerClient("discgolfdb");

builder.Services.AddSingleton<DbUpService>();

using IHost host = builder.Build();

var dbUpService = host.Services.GetRequiredService<DbUpService>();

dbUpService.Execute();