using FreelancerPlatform.Application;
using FreelancerPlatform.Client;
using FreelancerPlatform.Domain.Constans;
using FreelancerPlatform.Infratructure.Entityframework;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationService();
builder.Services.AddPresentService();
builder.Services.AddInfrastructureEntityFrameworkService(builder.Configuration);

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();


builder.Host.UseSerilog((context, config) =>
{
    config.WriteTo.Console();
});

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

app.UseStatusCodePagesWithReExecute("/404");

app.MapHub<ChatHub>("/chathub");

app.MapControllerRoute(
    name: "transaction",
    pattern: "giao-dich",
    defaults: new { controller = "Transaction", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "login",
    pattern: "dang-nhap",
    defaults: new { controller = "Acount", action = "Login" }
);

app.MapControllerRoute(
    name: "login",
    pattern: "dang-ky",
    defaults: new { controller = "Acount", action = "Register" }
);

app.MapControllerRoute(
    name: "logout",
    pattern: "dang-xuat",
    defaults: new { controller = "Acount", action = "Logout" }
);

app.MapControllerRoute(
    name: "profile",
    pattern: "ho-so",
    defaults: new { controller = "Freelancer", action = "Profile" }
);

app.MapControllerRoute(
    name: "editProfile",
    pattern: "chinh-ho-so",
    defaults: new { controller = "Freelancer", action = "EditProfile" }
);

app.MapControllerRoute(
    name: "editPassword",
    pattern: "chinh-mat-khau",
    defaults: new { controller = "Acount", action = "EditPassword" }
);

app.MapControllerRoute(
    name: "editPayment",
    pattern: "chinh-thong-tin-thanh-toan",
    defaults: new { controller = "Freelancer", action = "EditPayment" }
);

app.MapControllerRoute(
    name: "editPayment",
    pattern: "freelancer",
    defaults: new { controller = "Freelancer", action = "GetFreelancer" }
);

app.MapControllerRoute(
    name: "profile",
    pattern: "chi-tiet-freelancer/{id}",
    defaults: new { controller = "Freelancer", action = "GetFreelancerDetail" }
);

app.MapControllerRoute(
    name: "navigateHire",
    pattern: "nguoi-thue",
    defaults: new { controller = "Freelancer", action = "NavigateHire" }
);

app.MapControllerRoute(
    name: "navigateFreelancer",
    pattern: "thong-tin-cua-freelancer",
    defaults: new { controller = "Freelancer", action = "NavigateFreelancer" }
);

app.MapControllerRoute(
    name: "postJob",
    pattern: "dang-du-an",
    defaults: new { controller = "Job", action = "PostJob" }
);

app.MapControllerRoute(
    name: "editJob",
    pattern: "sua-du-an/{id}",
    defaults: new { controller = "Job", action = "EditJob" }
);

app.MapControllerRoute(
    name: "getJob",
    pattern: "tim-du-an",
    defaults: new { controller = "Job", action = "GetJob" }
);

app.MapControllerRoute(
    name: "getJobDetail",
    pattern: "chi-tiet-du-an/{id}",
    defaults: new { controller = "Job", action = "GetJobDetail" }
);

app.MapControllerRoute(
    name: "inbox",
    pattern: "tin-nhan",
    defaults: new { controller = "Inbox", action = "GetInbox" }
);




app.Run();