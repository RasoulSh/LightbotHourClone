using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    [RequireComponent(typeof(CanvasGroup))]
    public class AlphaTweener : Tweener
    {
        [SerializeField] [Range(0f, 1f)] private float from = 0f;
        [SerializeField] [Range(0f, 1f)] private float to = 1f;
        private CanvasGroup _canvasGroup;

        private CanvasGroup canvasGroup =>
            _canvasGroup != null ? _canvasGroup : _canvasGroup = GetComponent<CanvasGroup>();
        protected override void Animate(float t)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, t);
        }
    }
}