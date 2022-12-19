using System.Collections.Generic;
using System.Linq;
using LightbotHour.LevelInteractor.DTOs;
using LightbotHour.LevelService.Entities;

namespace LightbotHour.LevelInteractor.Mappers
{
    public static class LevelConfigMapper
    {
        public static LevelConfigDto MapToLevelConfigDto(IEnumerable<Level> levels)
        {
            return new LevelConfigDto()
            {
                Levels = levels.Select(LevelMapper.MapToLevelDto)
            };
        }
    }
}