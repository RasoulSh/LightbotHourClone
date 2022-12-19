using System.Collections;
using System.Collections.Generic;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.PlayerService.Abstraction;
using LightbotHour.ProgramService.Abstraction;
using UnityEngine;

namespace LightbotHour.LevelService.Application.CodeLines
{
    internal class BotCommandCode : IExecutable
    {
        private readonly BotAI _bot;
        private readonly BotCommands _command;

        public BotCommandCode(BotAI bot, BotCommands command)
        {
            _bot = bot;
            _command = command;
        }

        public IEnumerable<IEnumerator> ExecuteRoutines => new[]
        {
             _bot.InvokeCommandRoutine(_command)
        };
    }
}