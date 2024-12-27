using LabWeb13.Data.Repository;
using LabWeb13.Generator;
using LabWeb13.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<QuestionGenerator>();
builder.Services.AddSingleton<CalculationService>();
builder.Services.AddSingleton<QuestionRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();