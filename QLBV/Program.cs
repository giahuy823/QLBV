using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLBV.Models;
using QLBV.Models.User_Model;
using QLBV.Models.InterfaceRepository;
using static QLBV.Models.SeedRoles;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<QLBVContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString"));

});
builder.Services.AddScoped<InterfaceTaiKhoan, TaiKhoanRepository>();
builder.Services.AddScoped<InterfaceBenhVien, BenhVienRepository>();
builder.Services.AddScoped<InterfaceNhanVien, NhanVienRepository>();
builder.Services.AddTransient<IUserValidator<ApplicationUser>, CustomUserValidator>();

builder.Services.AddSession();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredUniqueChars = 1;
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.User.RequireUniqueEmail = false;
        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedEmail = false;
    }
    )
    .AddEntityFrameworkStores<QLBVContext>()
    .AddDefaultTokenProviders();
builder.Services.AddRazorPages();


var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaiKhoan}/{action=Login}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentityDataInitializer.SeedRoles(services);

    await SeedData.CreateUser(services);
}
app.Run();
