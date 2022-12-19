using LightbotHour.PlayerService.Abstraction;
using LightbotHour.PlayerService.Application;
using UnityEngine;

namespace LightbotHour.PlayerService
{
    [RequireComponent(typeof(Player))]
    public class PlayerPresenter : MonoBehaviour
    {
        private IPlayer _player;
        public IPlayer Player => _player ??= GetComponent<Player>();
    }
}