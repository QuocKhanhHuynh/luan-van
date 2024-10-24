using FreelancerPlatform._Admin;
using FreelancerPlatform.Application;
using FreelancerPlatform.Infratructure.Entityframework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationService();
builder.Services.AddPresentService();
builder.Services.AddInfrastructureEntityFrameworkService(builder.Configuration);

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "index",
    pattern: "trang-chu",
    defaults: new { controller = "Home", action = "Index" }
);

app.MapControllerRoute(
    name: "login",
    pattern: "dang-nhap",
    defaults: new { controller = "Acount", action = "Login" }
);

app.MapControllerRoute(
    name: "logout",
    pattern: "dang-xuat",
    defaults: new { controller = "Acount", action = "Login" }
);

app.MapControllerRoute(
    name: "admin",
    pattern: "quan-tri-vien",
    defaults: new { controller = "Acount", action = "GetAdmin" }
);

app.MapControllerRoute(
    name: "createAdmin",
    pattern: "them-tai-khoan",
    defaults: new { controller = "Acount", action = "CreateAdmin" }
);



app.Run();
