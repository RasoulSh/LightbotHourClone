namespace LightbotHour.InventoryService.Abstraction
{
    public interface IInventoryItem<T>
    {
        T Item { get; }
    }
}