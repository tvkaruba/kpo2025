namespace S4.HseCarShop.Models.Abstractions;

/// <summary>
/// Предоставляет описание двигателя
/// </summary>
public interface IEngine
{
    /// <summary>
    /// Тип двигателя
    /// </summary>
    EngineType Type { get; }
}
