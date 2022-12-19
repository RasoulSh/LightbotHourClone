using System.Collections.Generic;
using LightbotHour.InventoryService.Abstraction;

namespace LightbotHour.InventoryService.Application
{
    internal class Inventory<T> : IInventory<T>
    {
        public IEnumerable<IInventoryItem<T>> CurrentItems => _currentItems;
        private readonly IList<IInventoryItem<T>> _currentItems;

        public Inventory()
        {
            _currentItems = new List<IInventoryItem<T>>();
        }
        
        public IInventoryItem<T> AddItem(T item)
        {
            var newItem = new InventoryItem<T>(item);
            _currentItems.Add(newItem);
            return newItem;
        }

        public void RemoveItem(IInventoryItem<T> item)
        {
            _currentItems.Remove(item);
        }
    }
}