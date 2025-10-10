namespace S4.HseCarShop.Models.Abstractions;

/// <summary>
/// Предоставляет описание автомобиля
/// </summary>
public interface ICar
{
    /// <summary>
    /// Номер автомобиля
    /// </summary>
    public Guid Number { get; }

    /// <summary>
    /// Двигатель автомобиля
    /// </summary>
    public IEngine Engine { get; }

    /// <summary>
    /// Тип автомобиля
    /// </summary>
    public CarType Type { get; }
}
