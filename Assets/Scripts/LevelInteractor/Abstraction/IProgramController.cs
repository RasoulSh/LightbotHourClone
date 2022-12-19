using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.Abstraction
{
    public interface IProgramController
    {
        void AddCommand(BotCommandValue command);
        void RemoveCommand(int index);
        void RunProgram();
        event SuccessDelegate OnProgramRunFinished;
        delegate void SuccessDelegate(bool isSuccessful);
    }
}