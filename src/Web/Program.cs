﻿using Web.Components;
using Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IZaptecService, ZaptecService>();

builder.Services.AddHttpClient<IZaptecService, ZaptecService>(client =>
{
    client.BaseAddress = new("https://localhost:7226");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
