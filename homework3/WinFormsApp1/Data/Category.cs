using System.Xml.Serialization;

namespace WinFormsApp1.Data;

/// <summary>
/// (справочная таблица, сторона "один")
/// </summary>
public class Category
{
    /// <summary>
    /// Идентификатор категории (первичный ключ)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// Навигационное свойство: продукты категории
    /// </summary>
    [XmlIgnore]
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
