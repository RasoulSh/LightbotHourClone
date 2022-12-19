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
        void RunProgram();
        public event SuccessDelegate OnProgramRunFinished;
        delegate void SuccessDelegate(bool isSuccessful);
    }
}