using Microsoft.FeatureManagement;
using SQLApp.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    "Endpoint=https://azureappconfigurationdinessns.azconfig.io;Id=KWES;Secret=XjUokbqR34ShCVFyDKt6GL3QQZfCLWESzJeK1mMSawk=";

builder.Host.ConfigureAppConfiguration(x =>
{
    x.AddAzureAppConfiguration(y =>
    {
        y.Connect(connectionString).UseFeatureFlags();
    });

});

builder.Services.AddTransient<ProductService>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
