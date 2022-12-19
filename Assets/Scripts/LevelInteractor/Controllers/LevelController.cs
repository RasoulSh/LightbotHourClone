using System.Linq;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.DTOs;
using LightbotHour.LevelInteractor.Mappers;
using LightbotHour.LevelService;
using LightbotHour.LevelService.Abstraction;
using UnityEngine;

namespace LightbotHour.LevelInteractor.Controllers
{
    [RequireComponent(typeof(LevelPresenter))]
    internal class LevelController : MonoBehaviour, ILevelController
    {
        private ILevelManager _levelManager;
        public LevelConfigDto Config => LevelConfigMapper.MapToLevelConfigDto(_levelManager.Levels);
        public event ILevelController.LevelDelegate OnLevelChanged;
        public int CurrentLevelIndex { get; private set; } = -1;

        private void Start()
        {
            _levelManager = GetComponent<LevelPresenter>().LevelManager;
        }

        public void NextLevel() => ChangeLevel(CurrentLevelIndex + 1);
        public void ResetLevel() => ChangeLevel(CurrentLevelIndex);
        public void ChangeLevel(int index)
        {
            if (Config.Levels.Count() < index + 1)
            {
                return;
            }
            CurrentLevelIndex = index;
            _levelManager.PlayLevel(index);
            OnLevelChanged?.Invoke();
        }
    }
}