using System.Collections;
using LightbotHour.PlayerService.Entities;
using UnityEngine;

namespace LightbotHour.PlayerService.Application
{
    internal abstract class PlayerAnim : MonoBehaviour
    {
        [SerializeField] protected float delay = 0f;
        [SerializeField] protected float duration = 1f;
        public abstract IEnumerator PlayRoutine(Player player, PlayerLocation location);
    }
}