using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using Presentation.MediatorCommands;
using UnityEngine;

namespace LightbotHour.Presentation.Views
{
    public class InGameView : GUIPanel, ICommandHandler<SetInGamePanelsInteractable, bool>,
        ICommandHandler<ShowInGameView, bool>, ICommandHandler<HideInGameView, bool>
    {
        [SerializeField] private GUIPanel[] panels;

        public override bool Initialize()
        {
            if (base.Initialize() == false)
            {
                return false;
            }
            Mediator.Subscribe(this);
            return true;
        }

        private void OnDestroy()
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

        public bool Handle(ShowInGameView data)
        {
            Toggle(true);
            return true;
        }

        public bool Handle(HideInGameView data)
        {
            Toggle(false);
            return true;
        }
    }
}