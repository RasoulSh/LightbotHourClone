using System;
using System.Collections;
using UnityEngine;

namespace LightbotHour.Common.Utilities
{
    public static class AnimUtilities
    {
        public static IEnumerator AnimationRoutine(float delay,
            float duration, Action<float> tAction, bool realTime = false)
        {
            if (realTime)
            {
                yield return new WaitForSecondsRealtime(delay);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }
            if (duration == 0)
            {
                tAction(1f);
                yield break;
            }
            var startTime = realTime ? Time.unscaledTime : Time.time;
            var t = 0f;
            while (t < 1f)
            {
                t = ((realTime ? Time.unscaledTime : Time.time) - startTime) / duration;
                tAction(t);
                yield return null;
            }
            tAction(1f);
        }
    }
}
