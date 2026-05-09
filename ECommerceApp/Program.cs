var builder = WebApplication.CreateBuilder(args);

// We are telling the app: When someone asks for IAuthService, give them AuthService!
builder.Services.AddScoped<ECommerceApp.Services.IAuthService, ECommerceApp.Services.AuthService>();

// Add services to the container and attach our filter!
builder.Services.AddControllersWithViews(options =>
{
    // The Receptionist
    options.Filters.Add<ECommerceApp.Filters.LoggingFilter>();

    // The Paramedic!
    options.Filters.Add<ECommerceApp.Filters.GlobalExceptionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();