using LightbotHour.LevelInteractor.DTOs;
using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.Abstraction
{
    public interface ILevelController
    {
        int CurrentLevelIndex { get; }
        void NextLevel();
        void ResetLevel();
        void ChangeLevel(int index);
        LevelConfigDto Config { get; }
        event LevelDelegate OnLevelChanged;
        delegate void LevelDelegate();
    }
}