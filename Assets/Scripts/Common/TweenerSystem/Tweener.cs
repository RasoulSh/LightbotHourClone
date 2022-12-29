using System.Collections;
using System.Collections.Generic;
using Common.CommonEnums;
using LightbotHour.Common.TweenerSystem.Enums;
using LightbotHour.Common.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace LightbotHour.Common.TweenerSystem
{
    public abstract class Tweener : MonoBehaviour
    {
        [SerializeField] private TweenerConfig config;
        [SerializeField] private TweenerDelegation delegation;
        public TweenerConfig Config => config;
        public float TotalDuration => config.Duration + config.Delay;
        private float _currentT;
        private List<Coroutine> _currentRoutines;
        public TweenerDelegation Delegation => delegation;

        public void Play(TweenerPlayOrder playOrder, TweenerDirection direction)
        {
            switch (playOrder)
            {
                case TweenerPlayOrder.Once:
                    Play(direction);
                    break;
                case TweenerPlayOrder.Loop:
                    PlayLoop(direction);
                    break;
                case TweenerPlayOrder.PingPong:
                    PlayPingPong();
                    break;
            }
        }

        public void Play(bool isForward, bool ignoreAnimate = false)
        {
            Play(isForward ? TweenerDirection.Forward : TweenerDirection.Backward,
                ignoreAnimate);
        }

        public void Play(TweenerDirection direction, bool ignoreAnimate = false)
        {
            if (ignoreAnimate || gameObject.activeInHierarchy == false)
            {
                _currentT = direction == TweenerDirection.Forward ? 1 : 0;
                Animate(_currentT);
                delegation.InvokeFinishDelegates(direction);
            }
            else
            {
                StopCurrentRoutines();
                _currentRoutines.Add(StartCoroutine(PlayRoutine(direction)));
            }
        }
        public void Stop() => StopCurrentRoutines();
        
        [ContextMenu("PlayForward")]
        public void PlayForward() => Play(true);
        
        [ContextMenu("PlayBackward")]
        public void PlayBackward() => Play(false);

        public void PlayLoop(TweenerDirection direction)
        {
            StopCurrentRoutines();
            _currentRoutines.Add(StartCoroutine(PlayLoopRoutine(direction)));
        }

        private IEnumerator PlayLoopRoutine(TweenerDirection direction)
        {
            while (true)
            {
                yield return StartCoroutine(PlayRoutine(direction));
                _currentT = direction == TweenerDirection.Forward ? 0f : 1f;
            }
        }

        public void PlayPingPong() => PlayPingPong(TweenerDirection.Forward);
        public void PlayPingPong(TweenerDirection direction)
        {
            StopCurrentRoutines();
            _currentRoutines.Add(StartCoroutine(PlayPingPongRoutine(direction)));
        }
        
        private IEnumerator PlayPingPongRoutine(TweenerDirection direction)
        {
            while (true)
            {
                yield return StartCoroutine(
                    PlayRoutine(direction));
                yield return StartCoroutine(
                    PlayRoutine(direction == TweenerDirection.Forward
                        ? TweenerDirection.Backward
                        : TweenerDirection.Forward));
            }
        }

        private IEnumerator PlayRoutine(TweenerDirection direction)
        {
            delegation.InvokeStartDelegates(direction);
            yield return StartCoroutine(AnimUtilities.
                AnimationRoutine(config.Delay, config.Duration,
                    t => { ExecuteAnimate(t, direction);}, config.RealTime,
                    () => { delegation.InvokeFinishDelegates(direction); }));
        }
        
        private void StopCurrentRoutines()
        {
            if (_currentRoutines == null)
            {
                _currentRoutines = new List<Coroutine>();
                return;
            }
            _currentRoutines.ForEach(StopCoroutine);
            _currentRoutines.Clear();
        }

        private void ExecuteAnimate(float t, TweenerDirection direction = TweenerDirection.Forward)
        {
            _currentT = direction == TweenerDirection.Backward ? 1f - t : t;
            Animate( config.TweenerCurve.Evaluate(_currentT));
        }

        

        protected abstract void Animate(float t);
    }
}