using UnityEngine;

namespace LightbotHour.Presentation.Views.ViewTools
{
    public class ViewManager : MonoBehaviour
    {
        [SerializeField] private InventoryView inventoryView;
        [SerializeField] private LevelView levelView;
        [SerializeField] private ProgramView programView;

        public void GoToMenu()
        {
            levelView.gameObject.SetActive(true);
        }

        public void SetInteractable(bool isInteractable)
        {
            inventoryView.Interactable = isInteractable;
            programView.Interactable = isInteractable;
        }
    }
}