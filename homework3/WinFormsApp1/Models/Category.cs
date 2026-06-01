using System.Xml.Serialization;

namespace WinFormsApp1.Models;

/// <summary>
/// Главная сущность — Категория (master)
/// </summary>
public class Category
{
    /// <summary>Первичный ключ</summary>
    public int Id { get; set; }

    /// <summary>Название категории</summary>
    public string Name { get; set; } = "";

    /// <summary>Навигационное свойство: товары этой категории</summary>
    [XmlIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
