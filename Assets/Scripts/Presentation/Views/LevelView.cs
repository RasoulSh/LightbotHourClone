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
        [SerializeField] private GridLayoutGroup levelGrid;
        [SerializeField] private LevelItemGUI levelItemPrefab;
        private ILevelController _levelController;

        private void OnDestroy()
        {
            Mediator.Unsubscribe(this);
        }

        public override bool Initialize()
        {
            if (base.Initialize() == false)
            {
                return false;
            }
            Mediator.Subscribe(this);
            var presenter = Mediator.Send<GetLevelPresenter, LevelInteractorPresenter>();
            _levelController = presenter.LevelController;
            _levelController.OnLevelChanged += OnLevelChanged;
            var levels = _levelController.Config.Levels;
            var levelsCount = levels.Count();
            for (int i = 0; i < levelsCount; i++)
            {
                AddLevelItem(i);
            }
            return true;
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
            Mediator.Send<ShowInGameView, bool>();
        }

        public bool Handle(ShowLevelView data)
        {
            Toggle(true);
            return true;
        }
    }
}