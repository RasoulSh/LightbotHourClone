using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.LevelService.ValueObjects;

namespace LightbotHour.LevelInteractor.Mappers
{
    internal static class CommandValueMapper
    {
        public static BotCommands MapToBotCommand(BotCommandValue value)
        {
            return (BotCommands)value;
        }

        public static BotCommandValue MapToCommandValue(BotCommands command)
        {
            return (BotCommandValue)command;
        }
    }
}