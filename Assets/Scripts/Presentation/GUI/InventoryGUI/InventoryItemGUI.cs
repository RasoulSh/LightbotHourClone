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
        [SerializeField] private Button proc1Button;
        public BotCommandValue Command { get; private set; }
        public event InventoryItemDelegate OnSelectProc1;
        public event InventoryItemDelegate OnSelect;
        public delegate void InventoryItemDelegate(InventoryItemGUI inventoryItem);

        public void Initialize(BotCommandValue command, bool isProc1Available)
        {
            Command = command;
            titleLabel.text = BotCommandTranslator.Translate(command);
            proc1Button.gameObject.SetActive(isProc1Available);
        }
        
        private void Start()
        {
            selectButton.onClick.AddListener(Select);
            proc1Button.onClick.AddListener(SelectProc1);
        }

        private void SelectProc1()
        {
            OnSelectProc1?.Invoke(this);
        }

        private void Select()
        {
            OnSelect?.Invoke(this);
        }
    }
}