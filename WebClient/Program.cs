using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using WebClient.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FPTBooks");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDistributedMemoryCache();           // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
builder.Services.AddSession(cfg => {                    // Đăng ký dịch vụ Session
	cfg.Cookie.Name = "user";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
	cfg.IdleTimeout = new TimeSpan(0, 1000, 0);    // Thời gian tồn tại của Session
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("EmailID", policy =>
    policy.RequireClaim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "support@procodeguide.com"
    ));

    options.AddPolicy("AdminRole", policy =>
    policy.RequireRole("Admin")
    );
    options.AddPolicy("CustomerRole", policy =>
    policy.RequireRole("Customer")
    );
    options.AddPolicy("OwnerRole", policy =>
    policy.RequireRole("Owner")
    );
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area=Customer}/{controller=Book}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
app.MapRazorPages();
app.Run();
