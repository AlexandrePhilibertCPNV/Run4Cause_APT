using Microsoft.EntityFrameworkCore;
using Run4Cause.Data;
using Run4Cause.Models;
using Microsoft.AspNetCore.Identity;
using Tailwind;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Run4CauseContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSnakeCaseNamingConvention();
});

builder.Services
    .AddDefaultIdentity<User>()
    .AddSignInManager<SignInManager<User>>()
    .AddEntityFrameworkStores<Run4CauseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.RunTailwind("css:watch", "./");
}

// Check if the database is created. If not, create it.
using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    Run4CauseContext context = services.GetRequiredService<Run4CauseContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();