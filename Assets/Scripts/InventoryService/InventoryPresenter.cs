using LightbotHour.InventoryService.Abstraction;
using LightbotHour.InventoryService.Application;
using UnityEngine;

namespace LightbotHour.InventoryService
{
    public class InventoryPresenter : MonoBehaviour
    {
        public IInventory<T> NewInventory<T>() => new Inventory<T>();
    }
}