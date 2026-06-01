using System.IO;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data;

/// <summary>
/// Контекст базы данных приложения
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Путь к корню проекта (3 уровня вверх от bin/Debug/netX.Y-windows)
        var projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\"));
        var dbPath = Path.Combine(projectDir, "app.db");
        options.UseSqlite($"Data Source={dbPath}");
    }

    /// <summary>
    /// Заполнение базы данных начальными данными (4 категории, 12 товаров)
    /// </summary>
    public static void Seed(AppDbContext context)
    {
        if (context.Categories.Any())
            return; // База уже заполнена

        var categories = new List<Category>
        {
            new() { Name = "PC" },
            new() { Name = "PlayStation" },
            new() { Name = "Xbox" },
            new() { Name = "Nintendo" }
        };

        context.Categories.AddRange(categories);
        context.SaveChanges();

        var products = new List<Product>
        {
            new() { CategoryId = categories[0].Id, Name = "Cyberpunk 2077", Rating = 86 },
            new() { CategoryId = categories[0].Id, Name = "Baldur's Gate 3", Rating = 96 },
            new() { CategoryId = categories[0].Id, Name = "Counter-Strike 2", Rating = 88 },

            new() { CategoryId = categories[1].Id, Name = "God of War Ragnarok", Rating = 94 },
            new() { CategoryId = categories[1].Id, Name = "The Last of Us Part II", Rating = 93 },
            new() { CategoryId = categories[1].Id, Name = "Spider-Man 2", Rating = 90 },

            new() { CategoryId = categories[2].Id, Name = "Starfield", Rating = 73 },
            new() { CategoryId = categories[2].Id, Name = "Forza Horizon 5", Rating = 92 },
            new() { CategoryId = categories[2].Id, Name = "Halo Infinite", Rating = 78 },

            new() { CategoryId = categories[3].Id, Name = "Zelda: Tears of the Kingdom", Rating = 97 },
            new() { CategoryId = categories[3].Id, Name = "Super Mario Wonder", Rating = 91 },
            new() { CategoryId = categories[3].Id, Name = "Metroid Dread", Rating = 88 }
        };

        context.Products.AddRange(products);
        context.SaveChanges();
    }
}
