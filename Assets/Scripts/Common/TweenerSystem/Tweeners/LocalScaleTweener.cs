using LightbotHour.Common.TweenerSystem.AbstractTweeners;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    public class LocalScaleTweener : TransformTweener
    {
        protected override void Animate(float t)
        {
            Transform.localScale = Vector3.Lerp(From, To, t);
        }
    }
}