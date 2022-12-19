using System;
using LightbotHour.Common.Extensions;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.GUI.InventoryGUI;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private ProgramView programView;
        [SerializeField] private InventoryItemGUI itemPrefab;
        [SerializeField] private GridLayoutGroup itemGrid;
        [SerializeField] private CanvasGroup canvasGroup;
        private IInventoryController _inventoryController;

        public bool Interactable
        {
            get => canvasGroup.interactable;
            set => canvasGroup.interactable = value;
        }

        private void Start()
        {
            _inventoryController = presenter.InventoryController;
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
            programView.AddCodeItem(inventoryItem.Command);
        }
        
    }
}