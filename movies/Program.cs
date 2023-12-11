using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using movies.Models.Domain;
using movies.Repositories.Abstract;
using movies.Repositories.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddDbContext<MyDBContext>(option
    => option.UseSqlServer(builder.Configuration.GetConnectionString("MyConn")));


builder.Services.AddIdentity<ApplicationUser,IdentityRole>()
    .AddEntityFrameworkStores<MyDBContext>()
    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options=> options.LoginPath = "UserAuthentication/Login")

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
