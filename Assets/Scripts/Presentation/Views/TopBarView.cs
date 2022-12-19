using System;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class TopBarView : MonoBehaviour
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button backButton;
        private ILevelController _levelController;

        private void Start()
        {
            _levelController = presenter.LevelController;
            restartButton.onClick.AddListener(OnRestartButtonClicked);
            backButton.onClick.AddListener(BackToLevelView);
        }

        private void OnRestartButtonClicked()
        {
            _levelController.ResetLevel();
        }

        private void BackToLevelView()
        {
            Mediator.Send<ShowLevelView, bool>();
        }
    }
}