using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor.ValueObject;

namespace Presentation.MediatorCommands
{
    public class AddCodeItem : ICommand<bool>
    {
        public BotCommandValue Code { get; }
        
        public AddCodeItem(BotCommandValue code)
        {
            Code = code;
        }
    }
}