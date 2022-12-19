using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LightbotHour.LevelService.Entities;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.PlayerService.Abstraction;
using LightbotHour.PlayerService.Entities;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.LevelService.Application
{
    [RequireComponent(typeof(IPlayer))]
    [DisallowMultipleComponent]
    internal class BotAI : MonoBehaviour
    {
        [SerializeField] private LevelPipeline levelPipeline;
        [SerializeField] private float turnOnLightDuration = 1f;
        private Dictionary<Cube, CubeItem> _cubeItems;
        private Dictionary<Vector3Int, Cube> _cubes;
        private IPlayer _player;
        private Vector3Int _currentPlayerPoint;
        private Vector3Int _initialPlayerPoint;
        private PlayerRotation _initialPlayerRotation;

        public void Initialize(Dictionary<Cube, CubeItem> cubeItems,
            Vector3Int initialPlayerPoint, PlayerRotation initialPlayerRotation)
        {
            _player = GetComponent<IPlayer>();
            _cubeItems = cubeItems;
            _cubes = new Dictionary<Vector3Int, Cube>();
            _currentPlayerPoint = _initialPlayerPoint = initialPlayerPoint;
            _initialPlayerRotation = initialPlayerRotation;
            ResetLocation();
            foreach (var cube in _cubeItems.Keys)
            {
                _cubes.Add(cube.point, cube);
            }
        }

        public void ResetLocation()
        {
            _player.CurrentLocation = new PlayerLocation()
            {
                Rotation = _initialPlayerRotation,
                Position = levelPipeline.GetCubeTopPosition(_initialPlayerPoint)
            };
        }

        public IEnumerator InvokeCommandRoutine(BotCommands command)
        {
            if (command == BotCommands.Enlighten)
            {
                if (_cubes.TryGetValue(_currentPlayerPoint, out Cube cube))
                {
                    _cubeItems[cube].TurnOnLight();
                }

                yield return new WaitForSeconds(turnOnLightDuration);
                yield break;
            }

            if (command == BotCommands.RotLeft)
            {
                yield return StartCoroutine(_player.Rotate(CalculateRotateLeft(_player.CurrentLocation.Rotation)));
                yield break;
            }
            if (command == BotCommands.RotRight)
            {
                yield return StartCoroutine(_player.Rotate(CalculateRotateRight(_player.CurrentLocation.Rotation)));
                yield break;
            }

            _currentPlayerPoint = CalculateCommandPoint(command);
            var commandPosition = levelPipeline.GetCubeTopPosition(_currentPlayerPoint);
            if (command == BotCommands.Walk)
            {
                yield return StartCoroutine(_player.Walk(commandPosition));
                yield break;
            }
            yield return StartCoroutine(_player.Jump(commandPosition));
        }
        
        private Vector3Int CalculateCommandPoint(BotCommands command)
        {
            if (command == BotCommands.Enlighten)
            {
                return _currentPlayerPoint;
            }
            var frontDirection = GetFrontDirection();
            var frontPoint = _currentPlayerPoint + frontDirection;
            var frontUpPoint = frontPoint + Vector3Int.up;
            var isFrontBlocked = _cubes.ContainsKey(frontUpPoint);
            if (command == BotCommands.Walk)
            {
                if (isFrontBlocked) { return _currentPlayerPoint; }
                if (_cubes.ContainsKey(frontPoint) == false) { return _currentPlayerPoint; }
                return frontPoint;
            }
            if (isFrontBlocked)
            {
                return _cubes.ContainsKey(frontUpPoint + Vector3Int.up) ?
                    _currentPlayerPoint : frontUpPoint;
            }
            var frontDownPoint = frontPoint + Vector3Int.down;
            if (_cubes.ContainsKey(frontDownPoint) == false)
            {
                return _currentPlayerPoint;
            }
            return frontDownPoint;
        }

        private static PlayerRotation CalculateRotateLeft(PlayerRotation currRotation)
        {
            switch (currRotation)
            {
                case PlayerRotation.East:
                    return PlayerRotation.North;
                case PlayerRotation.North:
                    return PlayerRotation.West;
                case PlayerRotation.West:
                    return PlayerRotation.South;
                case PlayerRotation.South:
                    return PlayerRotation.East;
                default:
                    return 0;
            }
        }
        
        private static PlayerRotation CalculateRotateRight(PlayerRotation currRotation)
        {
            switch (currRotation)
            {
                case PlayerRotation.East:
                    return PlayerRotation.South;
                case PlayerRotation.South:
                    return PlayerRotation.West;
                case PlayerRotation.West:
                    return PlayerRotation.North;
                case PlayerRotation.North:
                    return PlayerRotation.East;
                default:
                    return 0;
            }
        }

        private Vector3Int GetFrontDirection()
        {
            return _player.CurrentLocation.Rotation switch
            {
                PlayerRotation.East => Vector3Int.right,
                PlayerRotation.West => Vector3Int.left,
                PlayerRotation.North => Vector3Int.forward,
                PlayerRotation.South => Vector3Int.back,
                _ => Vector3Int.zero
            };
        }
    }
}