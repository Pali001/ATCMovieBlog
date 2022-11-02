using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ATCMovieBlog.Data;
using ATCMovieBlog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ATCMovieBlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ATCMovieBlogContext") ?? throw new InvalidOperationException("Connection string 'ATCMovieBlogContext' not found.")));
builder.Services.AddSingleton<IAPI, API>();
builder.Services.AddSingleton<IAPI2, API2>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
