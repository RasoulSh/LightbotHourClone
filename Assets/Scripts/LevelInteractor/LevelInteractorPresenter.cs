using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.Controllers;
using UnityEngine;

namespace LightbotHour.LevelInteractor
{
    [RequireComponent(typeof(LevelController))]
    [RequireComponent(typeof(InventoryController))]
    [RequireComponent(typeof(ProgramController))]
    public class LevelInteractorPresenter : MonoBehaviour
    {
        private ILevelController _levelController;
        private IInventoryController _inventoryController;
        private IProgramController _programController;
        public ILevelController LevelController => _levelController ??= GetComponent<LevelController>();
        public IInventoryController InventoryController => _inventoryController ??= GetComponent<InventoryController>();
        public IProgramController ProgramController => _programController ??= GetComponent<ProgramController>();
    }
}