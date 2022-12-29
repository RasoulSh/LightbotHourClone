using System;
using Common.CommonEnums;
using LightbotHour.Common.TweenerSystem.Enums;
using UnityEngine;

namespace LightbotHour.Common.TweenerSystem
{
    [Serializable]
    public class TweenerConfig
    {
        [SerializeField] private float delay;
        [SerializeField] private float duration = 0.3f;
        [SerializeField] private AnimationCurve tweenerCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private bool realtime = true;

        public float Delay
        {
            get => delay;
            set => delay = value;
        }

        public float Duration
        {
            get => duration;
            set => duration = value;
        }

        public AnimationCurve TweenerCurve
        {
            get => tweenerCurve;
            set => tweenerCurve = value;
        }

        public bool RealTime
        {
            get => realtime;
            set => realtime = value;
        }
    }
}