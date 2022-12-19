using System.Collections.Generic;
using LightbotHour.LevelService.Application;
using LightbotHour.LevelService.Application.CodeLines;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.ProgramService.Abstraction;

namespace LevelService.Mappers
{
    internal static class CodeMapper
    {
        public static IEnumerable<IExecutable> MapToCode(IEnumerable<BotCommands> commands,
            BotAI bot)
        {
            var codes = new List<IExecutable>();
            foreach (var command in commands)
            {
                codes.Add(new BotCommandCode(bot, command));
            }
            return codes;
        }

        public static IExecutable MapToCode(BotCommands command, BotAI bot)
        {
            return new BotCommandCode(bot, command);
        }
    }
}