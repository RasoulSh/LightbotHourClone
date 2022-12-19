using System.Collections.Generic;
using LightbotHour.LevelService.Entities;
using LightbotHour.LevelService.ValueObjects;

namespace LightbotHour.LevelService.Abstraction
{
    public interface ILevelManager
    {
        IEnumerable<Level> Levels { get; }
        void PlayLevel(int levelIndex);
        Level CurrentLevel { get; }
        void AddCommand(BotCommands command);
        void RemoveCommand(int index);
        void AddCommandToProcedure1(BotCommands command);
        void RemoveCommandFromProcedure1(int index);
        void RunProgram();
        void StopProgram();
        public event SuccessDelegate OnProgramRunFinished;
        delegate void SuccessDelegate(bool isSuccessful);
    }
}