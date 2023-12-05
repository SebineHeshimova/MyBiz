using Exam.Business.Services.Implementation;
using Exam.Business.Services.Interface;
using Exam.Core.Repositories.Interface;
using Exam.Data.DAL;
using Exam.Data.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.AddDbContext<AppDbContext>(option => { option.UseSqlServer("Server=DESKTOP-AJGVV24;Database=MyBiz;Trusted_Connection=True;");});
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<ISliderService, SliderService>();
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
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
