using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    [RequireComponent(typeof(Graphic))]
    public class GraphicColorTweener : SingleTweener
    {
        [SerializeField] [Range(0f, 1f)] private Color from = Color.black;
        [SerializeField] [Range(0f, 1f)] private Color to = Color.white;
        public Color From
        {
            get => from;
            set => from = value;
        }
        public Color To
        {
            get => to;
            set => to = value;
        }
        private Graphic _graphic;

        private Graphic Graphic =>
            _graphic != null ? _graphic : _graphic = GetComponent<Graphic>();
        protected override void Animate(float t)
        {
            Graphic.color = Color.Lerp(from, to, t);
        }
    }
}