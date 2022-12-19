using System;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.Localization.Translators;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.GUI.InventoryGUI
{
    public class InventoryItemGUI : MonoBehaviour
    {
        [SerializeField] private Button selectButton;
        [SerializeField] private Text titleLabel;
        public BotCommandValue Command { get; private set; }
        public event InventoryItemDelegate OnSelect;
        public delegate void InventoryItemDelegate(InventoryItemGUI inventoryItem);

        public void Initialize(BotCommandValue command)
        {
            Command = command;
            titleLabel.text = BotCommandTranslator.Translate(command);
        }
        
        private void Start()
        {
            selectButton.onClick.AddListener(Select);
        }

        private void Select()
        {
            OnSelect?.Invoke(this);
        }
    }
}