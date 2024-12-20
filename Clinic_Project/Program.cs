using _0_Framework.Application;
using Clinic_Project;
using ClinicManagement.Infrastructure.Configuration;
using ClinicManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();



// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(connectionString));


ClinicManagementBootstrapper.Configure(builder.Services);


builder.Services.AddScoped<IFileUploader, FileUploader>();

builder.Services.AddSwaggerGen(option =>
option.SwaggerDoc("v1", new OpenApiInfo { Title = "Clinic API", Version = "v1" }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


//app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clinic API V1");
    c.RoutePrefix = "swagger";
    //c.RoutePrefix = string.Empty;
});



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.MapControllers();   


app.Run();
