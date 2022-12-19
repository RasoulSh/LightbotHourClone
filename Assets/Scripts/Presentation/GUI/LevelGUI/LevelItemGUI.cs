using UnityEngine;
using UnityEngine.UI;

namespace Presentation.GUI.LevelGUI
{
    public class LevelItemGUI : MonoBehaviour
    {
        [SerializeField] private Text levelNumberLabel;
        [SerializeField] private Button selectButton;
        public int LevelIndex { get; private set; }
        public event LevelItemDelegate OnSelect;
        public delegate void LevelItemDelegate(LevelItemGUI levelItem);
        private void Start()
        {
            selectButton.onClick.AddListener(Select);
        }

        public void Initialize(int levelIndex)
        {
            LevelIndex = levelIndex;
            levelNumberLabel.text = (levelIndex + 1).ToString();
        }

        private void Select()
        {
            OnSelect?.Invoke(this);
        }
    }
}