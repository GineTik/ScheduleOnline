using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScheduleOnline.BusinessLogic.Authorization;
using ScheduleOnline.Data.EF;
using ScheduleOnline.Data.Entities;
using ScheduleOnline.BusinessLogic.Mapper;
using System.Reflection;
using ScheduleOnline.Data.Repositories.Interfaces;
using ScheduleOnline.Data.Repositories.EFImplements;
using ScheduleOnline.Data.Repositories.IdentityImplements;
using ScheduleOnline.BusinessLogic.Factories;
using ScheduleOnline.Middlewares;
using ScheduleOnline.ServicesExtensions;

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

builder.Services.AddTransient<Authorizator>();
builder.Services.AddAutoMapper(
    Assembly.GetAssembly(typeof(MapperProfile)));

builder.Services.BindFactories();
builder.Services.BindRepositories();


// =====================

var app = builder.Build();

app.UseMiddleware<AuthenticateValidationMiddleware>();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();