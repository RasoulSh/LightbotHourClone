using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;
using MediatorSystem = Mediator.Mediator;

namespace LightbotHour.Presentation.Views
{
    public class TopBarView : GUIPanel
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button backButton;
        private ILevelController _levelController;

        public override bool Initialize()
        {
            if (base.Initialize() == false)
            {
                return false;
            }
            var presenter = MediatorSystem.Send<GetLevelPresenter, LevelInteractorPresenter>();
            _levelController = presenter.LevelController;
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            backButton.onClick.AddListener(BackToLevelView);
            return true;
        }

        private void OnRestartButtonClicked()
        {
            _levelController.ResetLevel();
        }

        private void BackToLevelView()
        {
            MediatorSystem.Send<ShowLevelView, bool>();
            MediatorSystem.Send<HideInGameView, bool>();
        }
    }
}