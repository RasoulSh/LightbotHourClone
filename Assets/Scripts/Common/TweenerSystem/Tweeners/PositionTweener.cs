using LightbotHour.Common.TweenerSystem.AbstractTweeners;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem.Tweeners
{
    public class PositionTweener : TransformTweener
    {
        protected override void Animate(float t)
        {
            Transform.position = Vector3.Lerp(From, To, t);
        }
    }
}