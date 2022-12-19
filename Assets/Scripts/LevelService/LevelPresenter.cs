using LightbotHour.LevelService.Abstraction;
using LightbotHour.LevelService.Application;
using UnityEngine;

namespace LightbotHour.LevelService
{
    [RequireComponent(typeof(LevelManager))]
    public class LevelPresenter : MonoBehaviour
    {
        private LevelManager _levelManager;
        public ILevelManager LevelManager => _levelManager ??= GetComponent<LevelManager>();
    }
}