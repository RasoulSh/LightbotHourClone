using System.Collections;
using LightbotHour.Common.TweenerSystem.Enums;
using LightbotHour.Common.Utilities;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem
{
    public abstract class SingleTweener : Tweener
    {
        [SerializeField] private TweenerConfig config;
        public TweenerConfig Config => config;
        public override float TotalDuration => config.Duration + config.Delay;
        private float _currentT;

        internal override IEnumerator PlayRoutine(TweenerDirection direction)
        {
            Delegation.InvokeStartDelegates(direction);
            yield return StartCoroutine(AnimUtilities.
                AnimationRoutine(config.Delay, config.Duration,
                    t => { ExecuteAnimate(t, direction);}, config.RealTime));
            Delegation.InvokeFinishDelegates(direction);
        }

        private void ExecuteAnimate(float t, TweenerDirection direction = TweenerDirection.Forward)
        {
            _currentT = direction == TweenerDirection.Backward ? 1f - t : t;
            Animate( config.TweenerCurve.Evaluate(_currentT));
        }
        
        protected abstract void Animate(float t);
        
        internal override void GotoFirstFrame()
        {
            ExecuteAnimate(0f);
        }

        internal override void GotoLastFrame()
        {
            ExecuteAnimate(1f);
        }
    }
}