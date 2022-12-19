using System;
using System.Collections.Generic;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.LevelService.Entities
{
    [Serializable]
    public struct Cube
    {
        public Vector3Int point;
        public bool hasLight;
    }
}