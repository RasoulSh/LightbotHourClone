using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.Presentation.Localization.Translators;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.GUI.ProgramGUI
{
    public class CodeItemGUI : MonoBehaviour
    {
        [SerializeField] private Text titleLabel;
        [SerializeField] private Button selectButton;
        public int Index { get; set; }
        public event CodeItemDelegate OnSelect;
        public delegate void CodeItemDelegate(CodeItemGUI codeItem);

        private void Start()
        {
            selectButton.onClick.AddListener(Select);
        }
        
        public void Initialize(int index, BotCommandValue command)
        {
            Index = index;
            titleLabel.text = BotCommandTranslator.Translate(command);
        }

        private void Select()
        {
            OnSelect?.Invoke(this);
        }
    }
}