using System;
using System.Collections.Generic;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.LevelService.Entities
{
    [Serializable]
    public class Level
    {
        public List<Cube> cubes;
        public List<BotCommands> availableCommands;
        public Vector3Int initialPlayerPoint;
        public PlayerRotation initialPlayerRotation;
    }
}