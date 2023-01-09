using System.Collections;
using TweenerSystem.Common.Utilities;
using LightbotHour.PlayerService.Entities;
using UnityEngine;

namespace LightbotHour.PlayerService.Application.PlayerAnims
{
    internal class PlayerJumpAnim : PlayerAnim
    {
        public override IEnumerator PlayRoutine(Player player, PlayerLocation location)
        {
            var playerTransform = player.transform;
            var startPosition = player.CurrentLocation.Position;
            var jumpPosition = startPosition;
            jumpPosition.y += 1f;
            var halfDuration = duration / 2f;
            yield return StartCoroutine(AnimUtilities.AnimationRoutine(delay, halfDuration,
                t =>
                {
                    playerTransform.position = Vector3.Lerp(startPosition, jumpPosition, t);
                }));
            yield return StartCoroutine(AnimUtilities.AnimationRoutine(0f, halfDuration,
                t =>
                {
                    playerTransform.position = Vector3.Lerp(jumpPosition, location.Position, t);
                }));
        }
    }
}