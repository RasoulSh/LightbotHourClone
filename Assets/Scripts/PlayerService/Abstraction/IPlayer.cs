using System.Collections;
using LightbotHour.PlayerService.Entities;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.PlayerService.Abstraction
{
    public interface IPlayer
    {
        PlayerLocation CurrentLocation { get; set; }
        IEnumerator Walk(Vector3 position);
        IEnumerator Rotate(PlayerRotation rotation);
        IEnumerator Jump(Vector3 position);
    }

}