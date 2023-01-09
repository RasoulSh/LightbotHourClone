using Mediator;
using LightbotHour.LevelInteractor.ValueObject;

namespace Presentation.MediatorCommands
{
    public class AddCodeItemToProc1 : ICommand<bool>
    {
        public BotCommandValue Code { get; }
        
        public AddCodeItemToProc1(BotCommandValue code)
        {
            Code = code;
        }
    }
}