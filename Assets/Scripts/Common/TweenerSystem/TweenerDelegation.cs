using System;
using LightbotHour.Common.TweenerSystem.Enums;
using UnityEngine.Events;

namespace LightbotHour.Common.TweenerSystem
{
    [Serializable]
    public class TweenerDelegation
    {
        public UnityEvent onStartPlaying;
        public UnityEvent onFinishPlaying;
        public UnityEvent onStartForward;
        public UnityEvent onStartBackward;
        public UnityEvent onFinishForward;
        public UnityEvent onFinishBackward;
        
        internal void InvokeStartDelegates(TweenerDirection direction)
        {
            onStartPlaying.Invoke();
            if (direction == TweenerDirection.Forward)
            {
                onStartForward.Invoke();
            }
            else
            {
                onStartBackward.Invoke();
            }
        }

        internal void InvokeFinishDelegates(TweenerDirection direction)
        {
            onFinishPlaying.Invoke();
            if (direction == TweenerDirection.Forward)
            {
                onFinishForward.Invoke();
            }
            else
            {
                onFinishBackward.Invoke();
            }
        }
    }
}