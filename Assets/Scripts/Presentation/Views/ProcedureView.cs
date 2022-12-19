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
        private IProgramController _programController;

        private void Start()
        {
            _programController = presenter.ProgramController;
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
            _programController.AddCommand(command);
        }
        
        private void OnEachItemSelect(CodeItemGUI codeItem)
        {
            _programController.RemoveCommand(codeItem.Index);
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
    }
}