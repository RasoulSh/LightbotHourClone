using LightbotHour.LevelInteractor.DTOs;
using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.Abstraction
{
    public interface ILevelController
    {
        void ChangeLevel(int index);
        LevelConfigDto Config { get; }
    }
}