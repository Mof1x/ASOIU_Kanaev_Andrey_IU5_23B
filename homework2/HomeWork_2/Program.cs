using HomeWork_2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

string dbPath = "games.db";
string projectDir = Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;
string platformsCsv = Path.Combine(projectDir, "platforms.csv");
string gamesCsv = Path.Combine(projectDir, "games.csv");

var db = new DatabaseManager(dbPath);
db.InitializeDatabase(platformsCsv, gamesCsv);

Console.WriteLine();

string choice;
do
{
    Console.WriteLine("========================================");
    Console.WriteLine("        УПРАВЛЕНИЕ ИГРАМИ               ");
    Console.WriteLine("========================================");
    Console.WriteLine("  1 — Показать все платформы            ");
    Console.WriteLine("  2 — Показать все игры                 ");
    Console.WriteLine("  3 — Добавить игру                     ");
    Console.WriteLine("  4 — Редактировать игру                ");
    Console.WriteLine("  5 — Удалить игру                      ");
    Console.WriteLine("  6 — Отчёты                            ");
    Console.WriteLine("  7 — Фильтр по платформе [ГРУППА Г]    ");
    Console.WriteLine("  8 — Экспорт в CSV [ГРУППА Б]          ");
    Console.WriteLine("  0 — Выход                             ");
    Console.WriteLine("========================================");
    Console.Write("Ваш выбор: ");

    choice = Console.ReadLine()?.Trim() ?? "";
    Console.WriteLine();

    switch (choice)
    {
        case "1": ShowPlatforms(db); break;
        case "2": ShowGames(db); break;
        case "3": AddGame(db); break;
        case "4": EditGame(db); break;
        case "5": DeleteGame(db); break;
        case "6": ReportsMenu(db); break;
        case "7": FilterByPlatform(db); break;
        case "8": ExportCsv(db); break;
        case "0": Console.WriteLine("Завершение"); break;
        default: Console.WriteLine("Введите цифру 0-9"); break;
    }
    Console.WriteLine();
} while (choice != "0");


static void ShowPlatforms(DatabaseManager db)
{
    Console.WriteLine("---- Все платформы ----");
    var platforms = db.GetAllPlatforms();
    foreach (var p in platforms)
        Console.WriteLine(" " + p);
    Console.WriteLine($"Итого: {platforms.Count}");
}

static void ShowGames(DatabaseManager db)
{
    Console.WriteLine("---- Все игры ----");
    var games = db.GetAllGames();
    foreach (var g in games)
        Console.WriteLine(" " + g);
    Console.WriteLine($"Итого: {games.Count}");
}

static void AddGame(DatabaseManager db)
{
    Console.WriteLine("---- Добавление игры ----");
    Console.WriteLine("Доступные платформы:");
    var platforms = db.GetAllPlatforms();
    foreach (var p in platforms)
        Console.WriteLine(" " + p);

    Console.Write("ID платформы: ");
    if (!int.TryParse(Console.ReadLine(), out int platformId))
    {
        Console.WriteLine("Ошибка: введите целое число.");
        return;
    }

    Console.Write("Название игры: ");
    string name = Console.ReadLine()?.Trim() ?? "";
    if (name.Length == 0)
    {
        Console.WriteLine("Ошибка: название не может быть пустым.");
        return;
    }

    Console.Write("Рейтинг (0-100): ");
    if (!int.TryParse(Console.ReadLine(), out int rating))
    {
        Console.WriteLine("Ошибка: введите целое число.");
        return;
    }

    try
    {
        var game = new Game(0, platformId, name, rating);
        db.AddGame(game);
        Console.WriteLine("Игра добавлена.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
}

static void EditGame(DatabaseManager db)
{
    Console.WriteLine("--- Редактирование игры ---");
    Console.Write("Введите ID игры: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Ошибка: введите целое число.");
        return;
    }

    var game = db.GetGameById(id);
    if (game == null)
    {
        Console.WriteLine($"Игра с ID={id} не найдена.");
        return;
    }

    Console.WriteLine($"Текущие данные: {game}");
    Console.WriteLine("(Нажмите Enter, чтобы оставить значение без изменений)");

    Console.Write($"Название [{game.Name}]: ");
    string input = Console.ReadLine()?.Trim() ?? "";
    if (input.Length > 0) game.Name = input;

    Console.Write($"ID платформы [{game.PlatformId}]: ");
    input = Console.ReadLine()?.Trim() ?? "";
    if (input.Length > 0 && int.TryParse(input, out int newPlatformId))
        game.PlatformId = newPlatformId;

    Console.Write($"Рейтинг [{game.Rating}]: ");
    input = Console.ReadLine()?.Trim() ?? "";
    if (input.Length > 0 && int.TryParse(input, out int newRating))
    {
        try
        {
            game.Rating = newRating;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return;
        }
    }

    db.UpdateGame(game);
    Console.WriteLine("Данные обновлены.");
}

static void DeleteGame(DatabaseManager db)
{
    Console.WriteLine("--- Удаление игры ---");
    Console.Write("Введите ID игры: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("Ошибка: введите целое число.");
        return;
    }

    var game = db.GetGameById(id);
    if (game == null)
    {
        Console.WriteLine($"Игра с ID={id} не найдена.");
        return;
    }

    Console.Write($"Удалить «{game.Name}»? (да/нет): ");
    string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";
    if (confirm == "да")
    {
        db.DeleteGame(id);
        Console.WriteLine("Игра удалена.");
    }
    else
    {
        Console.WriteLine("Удаление отменено.");
    }
}

// ============== Подменю отчётов ==============

static void ReportsMenu(DatabaseManager db)
{
    string choice;
    do
    {
        Console.WriteLine("------------------------ Отчёты ------------------------");
        Console.WriteLine(" 1 - Полный список игр с названиями платформ (JOIN)");
        Console.WriteLine(" 2 - Количество игр по платформам (GROUP BY + COUNT)");
        Console.WriteLine(" 3 - Средний рейтинг игр по платформам (GROUP BY + AVG)");
        Console.WriteLine(" 0 - Назад");
        Console.Write("Ваш выбор: ");
        choice = Console.ReadLine()?.Trim() ?? "";

        switch (choice)
        {
            case "1": Report1_GamesWithPlatforms(db); break;
            case "2": Report2_CountByPlatform(db); break;
            case "3": Report3_AvgRatingByPlatform(db); break;
            case "0": break;
            default: Console.WriteLine("Неверный пункт."); break;
        }
        Console.WriteLine();
    } while (choice != "0");
}

// Отчёт 1: Полный список игр с названиями платформ (JOIN)
static void Report1_GamesWithPlatforms(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"SELECT g.game_name, p.platform_name, g.rating 
                 FROM games g 
                 JOIN platforms p ON g.platform_id = p.platform_id 
                 ORDER BY g.game_name")
        .Title("Игры по платформам")
        .Header("Название игры", "Платформа", "Рейтинг")
        .ColumnWidths(30, 18, 10)
        .Numbered()
        .Footer("Всего записей")
        .Print();
}

// Отчёт 2: Количество игр по платформам (GROUP BY + COUNT)
static void Report2_CountByPlatform(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"SELECT p.platform_name, COUNT(*) AS game_count 
                 FROM games g 
                 JOIN platforms p ON g.platform_id = p.platform_id 
                 GROUP BY p.platform_name 
                 ORDER BY game_count DESC")
        .Title("Количество игр по платформам")
        .Header("Платформа", "Кол-во игр")
        .ColumnWidths(20, 12)
        .Print();
}

// Отчёт 3: Средний рейтинг игр по платформам (GROUP BY + AVG)
static void Report3_AvgRatingByPlatform(DatabaseManager db)
{
    new ReportBuilder(db)
        .Query(@"SELECT p.platform_name, ROUND(AVG(g.rating), 1) AS avg_rating 
                 FROM games g 
                 JOIN platforms p ON g.platform_id = p.platform_id 
                 GROUP BY p.platform_name 
                 ORDER BY avg_rating DESC")
        .Title("Средний рейтинг игр по платформам")
        .Header("Платформа", "Средний рейтинг")
        .ColumnWidths(20, 18)
        .SaveToFile("report_avg_rating.txt");
}

// [ГРУППА Г] Фильтр по платформе
static void FilterByPlatform(DatabaseManager db)
{
    Console.WriteLine("---- Фильтр по платформе ----");
    Console.WriteLine("Доступные платформы:");
    var platforms = db.GetAllPlatforms();
    foreach (var p in platforms)
        Console.WriteLine(" " + p);

    Console.Write("Введите ID платформы: ");
    if (!int.TryParse(Console.ReadLine(), out int platformId))
    {
        Console.WriteLine("Ошибка: введите целое число.");
        return;
    }

    var games = db.GetGamesByPlatform(platformId);
    if (games.Count == 0)
    {
        Console.WriteLine("На этой платформе нет игр.");
        return;
    }

    Console.WriteLine($"\nИгры на платформе #{platformId}:");
    foreach (var g in games)
        Console.WriteLine(" " + g);
    Console.WriteLine($"Итого: {games.Count}");
}

// [ГРУППА Б] Экспорт в CSV
static void ExportCsv(DatabaseManager db)
{
    string platformsPath = Path.Combine(AppContext.BaseDirectory, "platforms_export.csv");
    string gamesPath = Path.Combine(AppContext.BaseDirectory, "games_export.csv");
    db.ExportToCsv(platformsPath, gamesPath);
    Console.WriteLine($"Платформы экспортированы в: {platformsPath}");
    Console.WriteLine($"Игры экспортированы в: {gamesPath}");
}