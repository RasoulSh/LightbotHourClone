using System.Collections.Generic;

namespace LightbotHour.LevelInteractor.DTOs
{
    public struct LevelConfigDto
    {
        public IEnumerable<LevelDto> Levels { get; set; }
    }
}