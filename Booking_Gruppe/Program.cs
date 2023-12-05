using Booking_Gruppe.Services;
using Microsoft.AspNetCore.Authentication.Cookies; // Add this namespace
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; // Specify the login page
    });

// Other services...
builder.Services.AddSingleton<IPriserRepository>(provider => new PriserRepositoryJson());
builder.Services.AddSingleton<IUserRepository>(provider => new UserRepository(true));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication(); // Add this line to enable authentication
app.UseAuthorization();

app.MapRazorPages();

// Set the default page to "/Bookings/Booking"
app.MapFallbackToPage("/Bookings/Booking");

app.Run();