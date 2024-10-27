using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RADLab3Solution.Data;
using RADLab3Solution.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RADLab3SolutionContextSQLite>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RADLab3SolutionContextSQLite") ?? throw new InvalidOperationException("Connection string 'RADLab3SolutionContextSQLite' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
