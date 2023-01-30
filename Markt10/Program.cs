using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Markt10.DataAccess.Data;
using Markt10.Repository.IRepository;
using Markt10.Repository;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Markt10DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<Markt10DbContext>();
builder.Services.AddScoped<IUnitofWork, UnitofWork>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Admin"));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Customer/Login";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
    
app.Run();
