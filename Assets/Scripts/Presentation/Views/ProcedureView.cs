using LightbotHour.Common.Extensions;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using Presentation.GUI.ProgramGUI;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class ProcedureView : GUIPanel
    {
        [SerializeField] private LevelInteractorPresenter presenter;
        [SerializeField] private GridLayoutGroup codeItemGrid;
        [SerializeField] private CodeItemGUI codeItemPrefab;
        protected IProgramController programController;

        protected override void Start()
        {
            base.Start();
            programController = presenter.ProgramController;
        }

        public void Clear()
        {
            codeItemGrid.transform.DestroyAllChildren();
        }
        
        public void AddCodeItem(BotCommandValue command)
        {
            var newCodeItem = Instantiate(codeItemPrefab, codeItemGrid.transform);
            newCodeItem.Initialize(codeItemGrid.transform.childCount - 1, command);
            newCodeItem.OnSelect += OnEachItemSelect;
            AddCommand(command);
        }
        
        private void OnEachItemSelect(CodeItemGUI codeItem)
        {
            RemoveCommand(codeItem.Index);
            DestroyImmediate(codeItem.gameObject);
            RefreshIndexes();
        }

        private void RefreshIndexes()
        {
            var gridTransform = codeItemGrid.transform;
            var itemsCount = gridTransform.childCount;
            for (int i = 0; i < itemsCount; i++)
            {
                var item = gridTransform.GetChild(i).GetComponent<CodeItemGUI>();
                item.Index = i;
            }
        }

        protected virtual void AddCommand(BotCommandValue command)
        {
            programController.AddCommand(command);
        }

        protected virtual void RemoveCommand(int index)
        {
            programController.RemoveCommand(index);
        }
    }
}