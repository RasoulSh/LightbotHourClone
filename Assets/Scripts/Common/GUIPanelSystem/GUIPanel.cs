using System;
using UnityEngine;

namespace LightbotHour.Common.GUIPanelSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GUIPanel : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;
        
        protected virtual void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        
        public bool IsInteractable
        {
            get => _canvasGroup.interactable;
            set => _canvasGroup.interactable = value;
        }

        public void Toggle(bool isShown)
        {
            gameObject.SetActive(isShown);
        }
    }
}