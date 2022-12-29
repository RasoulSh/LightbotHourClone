using System;
using LightbotHour.Common.TweenerSystem;
using UnityEngine;

namespace LightbotHour.Common.GUIPanelSystem
{
    [RequireComponent(typeof(CanvasGroup))]
    public class GUIPanel : MonoBehaviour
    {
        [SerializeField] private bool isShown = true;
        [SerializeField] private bool initializeOnStart = true;
        private CanvasGroup _canvasGroup;
        private Tweener _tweener;
        public bool IsInitialized { get; private set; }

        protected virtual void Start()
        {
            if (IsInitialized)
            {
                return;
            }
            Initialize();
        }

        public virtual bool Initialize()
        {
            if (IsInitialized)
            {
                Debug.LogWarning("The GUI panel has been initialized already. You cannot initialize it twice");
                return false;
            }
            IsInitialized = true;
            _canvasGroup = GetComponent<CanvasGroup>();
            _tweener = GetComponent<Tweener>();
            if (_tweener != null)
            {
                _tweener.Play(isShown, true);
                _tweener.Delegation.onFinishPlaying.AddListener(OnTweenerFinishedPlaying);   
            }
            gameObject.SetActive(isShown);
            return true;
        }

        private void OnTweenerFinishedPlaying()
        {
            gameObject.SetActive(isShown);
        }

        public bool IsInteractable
        {
            get => _canvasGroup.interactable;
            set => _canvasGroup.interactable = value;
        }

        public void Toggle(bool isShown, bool ignoreAnimate = false)
        {
            if (IsInitialized == false)
            {
                Initialize();
            }
            if (this.isShown == isShown)
            {
                return;
            }
            this.isShown = isShown;
            if (_tweener == null)
            {
                gameObject.SetActive(isShown);
                return;
            }
            if (isShown)
            {
                _tweener.Play(false, true);
                gameObject.SetActive(true);
            }
            _tweener.Play(isShown, ignoreAnimate);
        }
    }
}