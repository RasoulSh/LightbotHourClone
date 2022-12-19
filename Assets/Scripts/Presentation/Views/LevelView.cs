using System.Linq;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using Presentation.GUI.LevelGUI;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class LevelView : GUIPanel, ICommandHandler<ShowLevelView, bool>
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private GridLayoutGroup levelGrid;
        [SerializeField] private LevelItemGUI levelItemPrefab;
        private ILevelController _levelController;

        protected override void Start()
        {
            base.Start();
            Mediator.Subscribe(this);
            _levelController = presenter.LevelController;
            _levelController.OnLevelChanged += OnLevelChanged;
            Initialize();
        }

        private void OnDestroy()
        {
            Mediator.Unsubscribe(this);
        }

        private void Initialize()
        {
            var levels = _levelController.Config.Levels;
            var levelsCount = levels.Count();
            for (int i = 0; i < levelsCount; i++)
            {
                AddLevelItem(i);
            }
        }

        private void AddLevelItem(int index)
        {
            var newLevelItem = Instantiate(levelItemPrefab, levelGrid.transform);
            newLevelItem.Initialize(index);
            newLevelItem.OnSelect += OnEachItemSelect;
        }

        private void OnEachItemSelect(LevelItemGUI levelItem)
        {
            _levelController.ChangeLevel(levelItem.LevelIndex);
        }

        private void OnLevelChanged()
        {
            Toggle(false);
        }

        public bool Handle(ShowLevelView data)
        {
            Toggle(true);
            return true;
        }
    }
}