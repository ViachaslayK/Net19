using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql;
using Data.Sql.Repositories;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.WikiServices;
using HealthyFoodWeb.Services.IServices;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(AuthService.AUTH_NAME)
    .AddCookie(AuthService.AUTH_NAME, x=>
    {
        x.LoginPath = "/User/Login";
        //x.AccessDeniedPath = "/User/AccessDenied";
    });


builder.Services.AddScoped<IGameService>(
    diContainer => new GameService(diContainer.GetService<IGameRepository>(), diContainer.GetService<IAuthService>()));
builder.Services.AddScoped<ICartService>(
    diContainer => new CartService(diContainer.GetService<ICartRepository>()));
builder.Services.AddScoped<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));
builder.Services.AddScoped<IWikiMCService>(
    diContainer => new WikiMCService(diContainer.GetService<IWikiMcRepository>(), diContainer.GetService<IAuthService>()));
builder.Services.AddScoped<IGameCatalogService>(
     diContainer => new GameCatalogService(diContainer.GetService<IGameCategoryRepository>()));
builder.Services.AddScoped<IAuthService>(
     diContainer => new AuthService(
            diContainer.GetService<IUserService>(), 
            diContainer.GetService<IHttpContextAccessor>()));

builder.Services.AddScoped<IWikiBAAPageServices>(x => new WikiBAAPageServices(x.GetService<IWikiBaaRepository>()));
builder.Services.AddScoped<IWikiBaaRepository>(x =>new WikiBaaRepository(x.GetService<WebContext>()));


builder.Services.AddScoped<IGameFruitConnectTwoService>(
     diContainer => new GameFruitConnectTwoService(diContainer.GetService<ISimilarGameRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);


builder.Services.AddSingleton<ICartRepository>(x => new CartRepositoryFake());
builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());
//builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());

builder.Services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<IGameCategoryRepository>(x => new GameCategoryRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<ISimilarGameRepository>(x => new SimilarGameRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<IGameRepository>(x => new GameRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<IWikiMcRepository>(x => new WikiMCImgRepository(x.GetService<WebContext>()));

builder.Services.AddHttpContextAccessor();

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

app.UseRouting();

app.UseAuthentication(); // ��� �?
app.UseAuthorization(); // ����� �� ����?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
