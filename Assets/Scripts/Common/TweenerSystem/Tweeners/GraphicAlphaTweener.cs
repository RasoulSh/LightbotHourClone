using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    [RequireComponent(typeof(Graphic))]
    public class GraphicAlphaTweener : SingleTweener
    {
        [SerializeField] [Range(0f, 1f)] private float from = 0f;
        [SerializeField] [Range(0f, 1f)] private float to = 1f;
        public float From
        {
            get => from;
            set => from = Mathf.Clamp01(value);
        }
        public float To
        {
            get => to;
            set => to = Mathf.Clamp01(value);
        }
        private Graphic _graphic;

        private Graphic Graphic =>
            _graphic != null ? _graphic : _graphic = GetComponent<Graphic>();
        protected override void Animate(float t)
        {
            var color = Graphic.color;
            color.a = Mathf.Lerp(from, to, t);
            Graphic.color = color;
        }
    }
}