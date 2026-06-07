using System.Xml.Serialization;

namespace WinFormsApp1.Data;

/// <summary>
/// (справочная таблица, сторона "много")
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор продукта (первичный ключ)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор категории (внешний ключ)
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Навигационное свойство: категория продукта
    /// </summary>
    [XmlIgnore]
    public Category? Category { get; set; }

    /// <summary>
    /// Название продукта
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Рейтинг продукта
    /// </summary>
    public int Rating { get; set; }
}
