using System.Collections.Generic;
using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.DTOs
{
    public struct LevelDto
    {
        public IEnumerable<BotCommandValue> AvailableCommands { get; set; }
    }
}