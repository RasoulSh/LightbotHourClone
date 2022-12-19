using System.Collections.Generic;
using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.Presentation.Localization.Translators
{
    public static class BotCommandTranslator
    {
        private static Dictionary<BotCommandValue, string> commandTitleDict;

        static BotCommandTranslator()
        {
            commandTitleDict = new Dictionary<BotCommandValue, string>()
            {
                { BotCommandValue.Walk, "Walk" },
                { BotCommandValue.Jump, "Jump"},
                { BotCommandValue.Enlighten, "Enlighten"},
                { BotCommandValue.RotLeft, "Rot Left"},
                { BotCommandValue.RotRight, "Rot Right"}
            };
        }
        
        public static string Translate(BotCommandValue command)
        {
            return commandTitleDict[command];
        }
    }
}