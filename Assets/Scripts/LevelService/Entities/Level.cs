using System;
using System.Collections.Generic;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.LevelService.Entities
{
    [Serializable]
    public struct Level
    {
        public Cube[] cubes;
        public BotCommands[] availableCommands;
        public Vector3Int initialPlayerPoint;
        public PlayerRotation initialPlayerRotation;
    }
}