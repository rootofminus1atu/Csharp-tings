using Microsoft.EntityFrameworkCore;
using PetsAndVetsLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
string solutionDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.Parent.FullName;
string dbPath = Path.Combine(solutionDirectory, "petsandvets.db");

builder.Services.AddDbContext<PetsAndVetsContext>(options =>
    options.UseSqlite($"Data Source={PetsAndVetsContext.GetDbPath()}"));

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
