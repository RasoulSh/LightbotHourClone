using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LightbotHour.Common.TweenerSystem.Enums;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    public class MultiTweener : Tweener
    {
        [SerializeField] private List<Tweener> tweeners;
        [SerializeField] private MultiTweenerPlayMode playMode;
        public List<Tweener> Tweeners => tweeners;

        public override float TotalDuration
        {
            get
            {
                switch (playMode)
                {
                    case MultiTweenerPlayMode.Simultaneous:
                        return tweeners.Max(tweener => tweener.TotalDuration);
                    case MultiTweenerPlayMode.Queue:
                        return tweeners.Sum(tweener => tweener.TotalDuration);
                    default:
                        return 0f;
                }
            }
        }
        internal override IEnumerator PlayRoutine(TweenerDirection direction)
        {
            Delegation.InvokeStartDelegates(direction);
            switch (playMode)
            {
                case MultiTweenerPlayMode.Simultaneous:
                    tweeners.ForEach(tweener => StartCoroutine(tweener.PlayRoutine(direction)));
                    yield return new WaitForSeconds(TotalDuration);
                    break;
                case MultiTweenerPlayMode.Queue:
                    foreach (var tweener in tweeners)
                    {
                        yield return StartCoroutine(tweener.PlayRoutine(direction));
                    }
                    break;
            }
            Delegation.InvokeFinishDelegates(direction);
        }

        internal override void GotoFirstFrame()
        {
            tweeners.ForEach(tweener => tweener.GotoFirstFrame());
        }

        internal override void GotoLastFrame()
        {
            tweeners.ForEach(tweener => tweener.GotoLastFrame());
        }
    }
}