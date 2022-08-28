using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScheduleContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, Role>(options =>
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequiredLength = 6,
        RequireLowercase = false,
        RequireUppercase = false,
        RequireNonAlphanumeric = false,
    }).AddEntityFrameworkStores<ScheduleContext>();

builder.Services.AddMvc();

// =====================

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();