using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using Presentation.MediatorCommands;
using UnityEngine;

namespace LightbotHour.Presentation.Views
{
    public class InGameView : MonoBehaviour, ICommandHandler<SetInGamePanelsInteractable, bool>
    {
        [SerializeField] private GUIPanel[] panels;

        private void OnEnable()
        {
            Mediator.Subscribe(this);
        }

        private void OnDisable()
        {
            Mediator.Unsubscribe(this);
        }

        public bool Handle(SetInGamePanelsInteractable data)
        {
            foreach (var panel in panels)
            {
                panel.IsInteractable = data.IsInteractable;
            }
            return true;
        }
    }
}