using System;
using LightbotHour.Common.Extensions;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.Common.Mediator;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.GUI.InventoryGUI;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class InventoryView : GUIPanel
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private InventoryItemGUI itemPrefab;
        [SerializeField] private GridLayoutGroup itemGrid;
        private IInventoryController _inventoryController;

        protected override void Start()
        {
            base.Start();
            _inventoryController = presenter.InventoryController;
            presenter.LevelController.OnLevelChanged += UpdateGUI;
        }

        public void UpdateGUI()
        {
            Clear();
            var commands = _inventoryController.CurrentAvailableCommands;
            foreach (var command in commands)
            {
                AddInventoryItem(command);
            }
        }

        private void Clear()
        {
            itemGrid.transform.DestroyAllChildren();
        }

        private void AddInventoryItem(BotCommandValue command)
        {
            var newItem = Instantiate(itemPrefab, itemGrid.transform);
            newItem.Initialize(command);
            newItem.OnSelect += OnEachItemSelect;
        }

        private void OnEachItemSelect(InventoryItemGUI inventoryItem)
        {
            Mediator.Send<AddCodeItem, bool>(new AddCodeItem(inventoryItem.Command));
        }
        
    }
}