using BloodBorne.Components;
using BloodBorne.Components.Account;
using BloodBorne.Components.Shared;
using BloodBorne.Context;
using BloodBorne.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
})
.AddIdentityCookies();

builder.Services.AddScoped<BossesProvider>();
builder.Services.AddScoped<ListItem>();
builder.Services.AddScoped<CommentProvider>();
builder.Services.AddScoped<TagProvider>();
builder.Services.AddScoped<UserProvider>();


builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddSignInManager();

builder.Services.AddScoped<DatabaseSeeder>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<DatabaseSeeder>();
await seeder!.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalAccountRoutes();

app.Run();
