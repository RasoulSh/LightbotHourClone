using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.PlayerService.Entities
{
    public struct PlayerLocation
    {
        public Vector3 Position { get; set; }
        public PlayerRotation Rotation { get; set; }
        
    }
}