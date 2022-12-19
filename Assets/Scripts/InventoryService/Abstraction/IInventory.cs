using System.Collections.Generic;

namespace LightbotHour.InventoryService.Abstraction
{
    public interface IInventory<T>
    {
        IEnumerable<IInventoryItem<T>> CurrentItems { get; }
        IInventoryItem<T> AddItem(T item);
        void RemoveItem(IInventoryItem<T> item);
    }
}