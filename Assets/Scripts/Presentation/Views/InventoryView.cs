using System.Linq;
using LightbotHour.Common.Extensions;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.GUI.InventoryGUI;
using Presentation.MediatorCommands;
using UnityEngine;
using UnityEngine.UI;
using MediatorSystem = Mediator.Mediator;

namespace LightbotHour.Presentation.Views
{
    public class InventoryView : GUIPanel
    {
        [SerializeField] private InventoryItemGUI itemPrefab;
        [SerializeField] private GridLayoutGroup itemGrid;
        private IInventoryController _inventoryController;

        public override bool Initialize()
        {
            if (base.Initialize() == false)
            {
                return false;
            }

            var presenter = MediatorSystem.Send<GetLevelPresenter, LevelInteractorPresenter>();
            _inventoryController = presenter.InventoryController;
            presenter.LevelController.OnLevelChanged += UpdateGUI;
            return true;
        }

        public void UpdateGUI()
        {
            Clear();
            var commands = _inventoryController.CurrentAvailableCommands;
            var isProc1Available = commands.Any(cmd => cmd == BotCommandValue.Proc1);
            foreach (var command in commands)
            {
                AddInventoryItem(command, isProc1Available);
            }
        }

        private void Clear()
        {
            itemGrid.transform.DestroyAllChildren();
        }

        private void AddInventoryItem(BotCommandValue command, bool isProc1Available)
        {
            var newItem = Instantiate(itemPrefab, itemGrid.transform);
            newItem.Initialize(command, isProc1Available);
            newItem.OnSelect += OnEachItemSelect;
            newItem.OnSelectProc1 += OnEachItemSelectProc1;
        }

        private void OnEachItemSelectProc1(InventoryItemGUI inventoryitem)
        {
            MediatorSystem.Send<AddCodeItemToProc1, bool>(new AddCodeItemToProc1(inventoryitem.Command));
        }

        private void OnEachItemSelect(InventoryItemGUI inventoryItem)
        {
            MediatorSystem.Send<AddCodeItem, bool>(new AddCodeItem(inventoryItem.Command));
        }
        
    }
}