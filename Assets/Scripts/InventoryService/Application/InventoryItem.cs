using LightbotHour.InventoryService.Abstraction;

namespace LightbotHour.InventoryService.Application
{
    internal class InventoryItem<T>: IInventoryItem<T>
    {
        public T Item { get; }
        
        public InventoryItem(T item)
        {
            Item = item;
        }
    }
}