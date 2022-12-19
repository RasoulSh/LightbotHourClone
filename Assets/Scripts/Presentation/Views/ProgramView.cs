using System;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class ProgramView : GUIPanel, ICommandHandler<AddCodeItem, bool>
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private ProcedureView mainProcedureView;
        [SerializeField] private Button runButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button retryButton;
        private IProgramController _programController;
        private ILevelController _levelController;

        protected override void Start()
        {
            base.Start();
            _programController = presenter.ProgramController;
            _levelController = presenter.LevelController;
            _programController.OnProgramRunFinished += OnProgramRunFinished;
            _levelController.OnLevelChanged += Clear;
            runButton.onClick.AddListener(RunProgram);
            nextLevelButton.onClick.AddListener(_levelController.NextLevel);
            retryButton.gameObject.SetActive(false);
            retryButton.onClick.AddListener(Retry);
        }

        private void OnEnable()
        {
            Mediator.Subscribe(this);
        }

        private void OnDisable()
        {
            Mediator.Unsubscribe(this);
        }

        private void Retry()
        {
            _levelController.ResetLevel();
            Mediator.Send<SetInGamePanelsInteractable, bool>(
                new SetInGamePanelsInteractable(true));
        }

        private void OnProgramRunFinished(bool isSuccessful)
        {
            if (isSuccessful)
            {
                nextLevelButton.gameObject.SetActive(true);
                return;
            }
            retryButton.gameObject.SetActive(true);
        }

        private void RunProgram()
        {
            runButton.interactable = false;
            Mediator.Send<SetInGamePanelsInteractable, bool>(
                new SetInGamePanelsInteractable(false));
            _programController.RunProgram();
        }

        private void Clear()
        {
            mainProcedureView.Clear();
            runButton.interactable = true;
            retryButton.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            Mediator.Send<SetInGamePanelsInteractable, bool>(
                new SetInGamePanelsInteractable(true));
        }

        private void AddCodeItem(BotCommandValue code)
        {
            mainProcedureView.AddCodeItem(code);
        }

        public bool Handle(AddCodeItem data)
        {
            AddCodeItem(data.Code);
            return true;
        }
    }
}