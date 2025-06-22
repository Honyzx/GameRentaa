using BlazorApp4.Components;
using DataBank;
using Microsoft.EntityFrameworkCore;
using Pattern;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBConnectionContext>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

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
using (var serviceScope = app.Services.CreateScope())
{
    var db = serviceScope.ServiceProvider.GetRequiredService<DBConnectionContext>();
    db.Database.Migrate();
    if (!db.Games.Any())
    {
        var video = new Category {Name = "Видео игры"};
        var board = new Category {Name = "Настольные игры"}; 
        db.Games.AddRange(
            new Game { Title = "Horizon Zero Dawn Remastered PS5", Description = "499", DailyRentalPrice = 499 , Category = video, GameID = 1,  },
            new Game { Title  = "ELDEN RING NIGHTREIGN PS4 & PS5", Description = "https://igroarenda.ru/image/cache/catalog/hzz-500x500.jpg", DailyRentalPrice = 899 , Category = video, GameID = 2,},
            new Game { Title  = "Alien: Isolation", Description = "https://igroarenda.ru/image/cache/catalog/alien-500x500.jpg", DailyRentalPrice = 99 , Category = video , GameID = 3,},
            new Game { Title  = "Forza Horizon 5 Standard Edition PS5", Description = "https://igroarenda.ru/image/cache/catalog/reviews/forzz-500x500.jpg", DailyRentalPrice = 899, Category = video, GameID = 4, },
            new Game { Title  = "Бункер настольная игра", Description = "https://www.tdkarandash.ru/upload/iblock/9f2/74mdg4b5gxprb9b72qbz6in3f44tw2uj.jpg", DailyRentalPrice = 199 ,Category = board, GameID = 5, },
            new Game { Title  = "Детективные истории: Последний рейс Гаттардо", Description = "https://www.tdkarandash.ru/upload/resize_cache/iblock/17b/450_450_140cd750bba9870f18aada2478b24840a/p9y01c8zalmpjhthz1ntxk147flw0f7g.jpg", DailyRentalPrice = 399 , Category = board, GameID = 6, }
        );
        db.SaveChanges();
    }
}

app.Run();