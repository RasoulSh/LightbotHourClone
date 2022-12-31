using UnityEngine;

namespace LightbotHour.Common.TweenerSystem.AbstractTweeners
{
    public abstract class TransformTweener : SingleTweener
    {
        [SerializeField] private Vector3 from = Vector3.zero;
        [SerializeField] private Vector3 to = Vector3.zero;
        public Vector3 From
        {
            get => from;
            set => from = value;
        }
        public Vector3 To
        {
            get => to;
            set => to = value;
        }
        private Transform _transform;
        protected Transform Transform => 
            _transform != null ? _transform : _transform = GetComponent<Transform>();
    }
}