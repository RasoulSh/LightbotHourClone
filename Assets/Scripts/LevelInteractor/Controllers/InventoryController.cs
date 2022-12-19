using System.Collections.Generic;
using System.Linq;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.Mappers;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.LevelService;
using LightbotHour.LevelService.Abstraction;
using UnityEngine;

namespace LightbotHour.LevelInteractor.Controllers
{
    [RequireComponent(typeof(LevelPresenter))]
    internal class InventoryController : MonoBehaviour, IInventoryController
    {
        private ILevelManager _levelManager;
        public IEnumerable<BotCommandValue> CurrentAvailableCommands =>
            _levelManager.CurrentLevel.availableCommands.Select(CommandValueMapper.MapToCommandValue);
        
        private void Start()
        {
            _levelManager = GetComponent<LevelPresenter>().LevelManager;
        }
    }
}