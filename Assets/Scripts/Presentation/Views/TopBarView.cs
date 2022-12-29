using System;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;

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
            var presenter = Mediator.Send<GetLevelPresenter, LevelInteractorPresenter>();
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
            Mediator.Send<ShowLevelView, bool>();
            Mediator.Send<HideInGameView, bool>();
        }
    }
}