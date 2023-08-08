using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.Logging;
using VisusCore.TenantHostedService.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLogHost();

builder.Services.AddOrchardCms(builder => builder.AddTenantHostedService());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseOrchardCore();

app.Run();
