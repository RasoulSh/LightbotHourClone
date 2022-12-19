using System.Collections;
using LightbotHour.Common.Utilities;
using LightbotHour.PlayerService.Abstraction;
using LightbotHour.PlayerService.Entities;
using UnityEngine;

namespace LightbotHour.PlayerService.Application.PlayerAnims
{
    internal class PlayerWalkAnim : PlayerAnim
    {
        public override IEnumerator PlayRoutine(Player player, PlayerLocation location)
        {
            var playerTransform = player.transform;
            var startPosition = player.CurrentLocation.Position;
            var startRotation = playerTransform.eulerAngles;
            var targetRotation = Vector3.up * (float)player.CurrentLocation.Rotation;
            yield return StartCoroutine(AnimUtilities.AnimationRoutine(delay, duration,
                t =>
                {
                    playerTransform.position = Vector3.Lerp(startPosition, location.Position, t);
                    playerTransform.eulerAngles = Vector3.Lerp(startRotation, targetRotation, t);
                }));
        }
    }
}