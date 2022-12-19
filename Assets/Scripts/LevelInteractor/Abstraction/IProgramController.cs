using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.LevelInteractor.Abstraction
{
    public interface IProgramController
    {
        void AddCommand(BotCommandValue command);
        void RemoveCommand(int index);

        void AddCommandToProcedure1(BotCommandValue command);
        void RemoveCommandFromProcedure1(int index);
        void RunProgram();
        void StopProgram();
        event SuccessDelegate OnProgramRunFinished;
        delegate void SuccessDelegate(bool isSuccessful);
    }
}