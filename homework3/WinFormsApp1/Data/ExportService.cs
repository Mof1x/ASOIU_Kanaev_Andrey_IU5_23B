using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using WinFormsApp1.Models;

namespace WinFormsApp1.Data;

/// <summary>
/// Сервис экспорта данных в XML
/// </summary>
public static class ExportService
{
    /// <summary>
    /// Экспортирует все данные (категории и товары) в XML-файл
    /// </summary>
    public static void ExportToXml(string filePath)
    {
        using var context = new AppDbContext();

        var categories = context.Categories
            .OrderBy(c => c.Name)
            .ToList();

        var products = context.Products
            .Include(p => p.Category)
            .OrderBy(p => p.Name)
            .ToList();

        // Загружаем навигационные свойства в память перед сериализацией
        // (после Dispose контекста они будут недоступны)
        var exportData = new ExportData
        {
            Categories = categories,
            Products = products
        };

        var serializer = new XmlSerializer(typeof(ExportData));
        using var writer = new StreamWriter(filePath, false, System.Text.Encoding.UTF8);
        serializer.Serialize(writer, exportData);
    }
}

/// <summary>
/// Класс-обёртка для экспорта данных в XML
/// </summary>
[XmlRoot("CatalogData")]
public class ExportData
{
    [XmlArray("Categories")]
    [XmlArrayItem("Category")]
    public List<Category> Categories { get; set; } = new();

    [XmlArray("Products")]
    [XmlArrayItem("Product")]
    public List<Product> Products { get; set; } = new();
}
