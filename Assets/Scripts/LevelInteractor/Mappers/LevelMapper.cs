using System.Linq;
using LightbotHour.LevelInteractor.DTOs;
using LightbotHour.LevelService.Entities;

namespace LightbotHour.LevelInteractor.Mappers
{
    internal static class LevelMapper
    {
        public static LevelDto MapToLevelDto(Level level)
        {
            return new LevelDto()
            {
                AvailableCommands = level.availableCommands.Select(CommandValueMapper.MapToCommandValue)
            };
        }
    }
}