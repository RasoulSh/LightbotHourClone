using System;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Mediator.Subscribe(this);
        }

        private void OnDestroy()
        {
            Mediator.Unsubscribe(this);
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