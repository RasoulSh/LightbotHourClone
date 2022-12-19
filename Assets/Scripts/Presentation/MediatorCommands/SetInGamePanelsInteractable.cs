using LightbotHour.Common.Mediator;

namespace Presentation.MediatorCommands
{
    public class SetInGamePanelsInteractable : ICommand<bool>
    {
        public bool IsInteractable { get; }
        
        public SetInGamePanelsInteractable(bool isInteractable)
        {
            IsInteractable = isInteractable;
        }
    }
}