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
        private void Start()
        {
            _levelManager = GetComponent<LevelPresenter>().LevelManager;
        }

        public void ChangeLevel(int index)
        {
            _levelManager.PlayLevel(index);
        }
    }
}