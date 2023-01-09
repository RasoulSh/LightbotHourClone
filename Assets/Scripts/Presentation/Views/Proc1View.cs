using LightbotHour.LevelInteractor.ValueObject;

namespace LightbotHour.Presentation.Views
{
    public class Proc1View : ProcedureView
    {
        protected override void AddCommand(BotCommandValue command)
        {
            programController.AddCommandToProcedure1(command);
        }

        protected override void RemoveCommand(int index)
        {
            programController.RemoveCommandFromProcedure1(index);
        }
    }
}