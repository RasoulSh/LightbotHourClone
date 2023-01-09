using Mediator;
using LightbotHour.LevelInteractor;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.SceneManagement;
using MediatorSystem = Mediator.Mediator;

namespace Presentation
{
    public class LevelProvider : MonoBehaviour, ICommandHandler<GetLevelPresenter, LevelInteractorPresenter>
    {
        [SerializeField] private string levelScene;
        [SerializeField] private string presenterGameObjectName;
        private LevelInteractorPresenter _presenter;

        private void Awake()
        {
            SceneManager.LoadScene(levelScene, LoadSceneMode.Additive);
            MediatorSystem.Subscribe(this);
        }

        private void OnDestroy()
        {
            MediatorSystem.Unsubscribe(this);
        }

        public LevelInteractorPresenter Handle(GetLevelPresenter data)
        {
            if (_presenter != null)
            {
                return _presenter;
            }

            var go = GameObject.Find(presenterGameObjectName);
            _presenter = go.GetComponent<LevelInteractorPresenter>();
            return _presenter;
        }
    }
}