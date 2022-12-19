using System.Collections.Generic;
using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.Abstraction
{
    public interface IInventoryController
    {
        IEnumerable<BotCommandValue> CurrentAvailableCommands { get; }
    }
}