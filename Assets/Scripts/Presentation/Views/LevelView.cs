using System;
using System.Linq;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using Presentation.GUI.LevelGUI;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private ProgramView programView;
        [SerializeField] private GridLayoutGroup levelGrid;
        [SerializeField] private LevelItemGUI levelItemPrefab;
        private ILevelController _levelController;
        private int currentLevelIndex;

        private void Start()
        {
            _levelController = presenter.LevelController;
            Initialize();
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
            SelectLevel(levelItem.LevelIndex);
        }

        public void ResetLevel()
        {
            SelectLevel(currentLevelIndex);
        }

        public void NextLevel()
        {
            SelectLevel(currentLevelIndex + 1);
        }

        public void SelectLevel(int index)
        {
            if (_levelController.Config.Levels.Count() < index + 1)
            {
                return;
            }
            currentLevelIndex = index;
            _levelController.ChangeLevel(index);
            inventoryView.UpdateGUI();
            programView.Clear();
            Toggle(false);
        }

        public void Toggle(bool isShown)
        {
            gameObject.SetActive(isShown);
        }
    }
}