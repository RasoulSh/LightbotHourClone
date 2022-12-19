using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.Views.ViewTools;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class ProgramView : MonoBehaviour
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private LevelView levelView;
        [SerializeField] private ViewManager viewManager;
        [SerializeField] private ProcedureView mainProcedureView;
        [SerializeField] private Button runButton;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button backButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private CanvasGroup canvasGroup;
        private IProgramController _programController;
        public bool Interactable
        {
            get => canvasGroup.interactable;
            set => canvasGroup.interactable = value;
        }

        private void Start()
        {
            _programController = presenter.ProgramController;
            runButton.onClick.AddListener(RunProgram);
            _programController.OnProgramRunFinished += OnProgramRunFinished;
            retryButton.gameObject.SetActive(false);
            retryButton.onClick.AddListener(Retry);
            restartButton.onClick.AddListener(levelView.ResetLevel);
            backButton.onClick.AddListener(viewManager.GoToMenu);
            nextLevelButton.onClick.AddListener(levelView.NextLevel);
        }

        private void Retry()
        {
            levelView.ResetLevel();
            viewManager.SetInteractable(true);
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
            viewManager.SetInteractable(false);
            _programController.RunProgram();
        }

        public void Clear()
        {
            mainProcedureView.Clear();
            runButton.interactable = true;
            retryButton.gameObject.SetActive(false);
            nextLevelButton.gameObject.SetActive(false);
            viewManager.SetInteractable(true);
        }

        public void AddCodeItem(BotCommandValue code)
        {
            mainProcedureView.AddCodeItem(code);
        }
    }
}