using System;
using System.Linq;
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
    public class ProgramView : GUIPanel, ICommandHandler<AddCodeItem, bool>,
        ICommandHandler<AddCodeItemToProc1, bool>
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private ProcedureView mainProcedureView;
        [SerializeField] private Proc1View procedure1View;
        [SerializeField] private Button runButton;
        [SerializeField] private Button stopButton;
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
            stopButton.onClick.AddListener(StopProgram);
            nextLevelButton.onClick.AddListener(_levelController.NextLevel);
            retryButton.gameObject.SetActive(false);
            stopButton.gameObject.SetActive(false);
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
            stopButton.gameObject.SetActive(false);
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
            stopButton.gameObject.SetActive(true);
            Mediator.Send<SetInGamePanelsInteractable, bool>(
                new SetInGamePanelsInteractable(false));
            _programController.RunProgram();
        }
        
        private void StopProgram()
        {
            stopButton.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(true);
            _programController.StopProgram();
        }

        private void Clear()
        {
            mainProcedureView.Clear();
            procedure1View.Clear();
            runButton.interactable = true;
            stopButton.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            Mediator.Send<SetInGamePanelsInteractable, bool>(
                new SetInGamePanelsInteractable(true));
            var currentLevel = _levelController.Config.Levels.ElementAt(_levelController.CurrentLevelIndex);
            var isProc1Available = currentLevel.AvailableCommands.Any(cmd => cmd == BotCommandValue.Proc1);
            procedure1View.gameObject.SetActive(isProc1Available);
        }

        public bool Handle(AddCodeItem data)
        {
            mainProcedureView.AddCodeItem(data.Code);
            return true;
        }

        public bool Handle(AddCodeItemToProc1 data)
        {
            procedure1View.AddCodeItem(data.Code);
            return true;
        }
    }
}