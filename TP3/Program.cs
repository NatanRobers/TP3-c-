using TP3.Data;
using Microsoft.EntityFrameworkCore;
using TP3.Services;
using TP3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IPropertyService, PropertyService>();
builder.Services.AddDbContext<CityBreaksContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("CityBreaksConnection")));
builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
