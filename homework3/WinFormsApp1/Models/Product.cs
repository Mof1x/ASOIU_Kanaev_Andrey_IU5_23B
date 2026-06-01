using System.Xml.Serialization;

namespace WinFormsApp1.Models;

/// <summary>
/// Подчинённая сущность — Товар (detail)
/// </summary>
public class Product
{
    /// <summary>Первичный ключ</summary>
    public int Id { get; set; }

    /// <summary>Внешний ключ на категорию</summary>
    public int CategoryId { get; set; }

    /// <summary>Навигационное свойство: категория товара</summary>
    [XmlIgnore]
    public Category? Category { get; set; }

    /// <summary>Название товара</summary>
    public string Name { get; set; } = "";

    /// <summary>Рейтинг товара (0–100)</summary>
    public int Rating { get; set; }
}
