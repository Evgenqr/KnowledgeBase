using KnowledgeBase.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
        name: "DocumentDetails",
        pattern: "document/{id}",
        defaults: new { controller = "Document", action = "Details" });

app.MapControllerRoute(
    name: "CreateDocument",
    pattern: "create",
    defaults: new { controller = "Document", action = "Create" });

app.MapRazorPages();

app.MapControllerRoute(
        name: "DocumentDelete",
        pattern: "document/delete/{id}",
        defaults: new { controller = "Document", action = "Delete" });

app.MapControllerRoute(
        name: "DocumentEdit",
        pattern: "document/{id}/edit",
        defaults: new { controller = "Document", action = "Edit" });

app.MapControllerRoute(
        name: "CategoryIndex",
        pattern: "category/{id}",
        defaults: new { controller = "Category", action = "Index" });

app.MapControllerRoute(
        name: "DepartmentIndex",
        pattern: "department/{id}",
        defaults: new { controller = "Department", action = "Index" });

app.MapControllerRoute(
        name: "LawIndex",
        pattern: "laws/{id}",
        defaults: new { controller = "Laws", action = "Index" });


app.Run();
