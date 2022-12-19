using System;
using System.Collections;
using LightbotHour.PlayerService.Abstraction;
using LightbotHour.PlayerService.Application.PlayerAnims;
using LightbotHour.PlayerService.Entities;
using LightbotHour.PlayerService.ValueObjects;
using UnityEngine;

namespace LightbotHour.PlayerService.Application
{
    internal class Player : MonoBehaviour, IPlayer
    {
        [SerializeField] private PlayerWalkAnim walkAnim;
        [SerializeField] private PlayerJumpAnim jumpAnim;
        private Transform _transform;
        private PlayerLocation _currentLocation;
        public PlayerLocation CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                _transform.position = _currentLocation.Position;
                _transform.eulerAngles = Vector3.up * (float)_currentLocation.Rotation;
            }
        }

        private void Start()
        {
            _transform = transform;
        }

        public IEnumerator Walk(Vector3 position)
        {
            if (walkAnim != null)
            {
                yield return StartCoroutine(walkAnim.PlayRoutine(this, new PlayerLocation()
                {
                    Position = position,
                    Rotation = CurrentLocation.Rotation
                }));
            }
            _currentLocation.Position = position;
            _transform.position = position;
        }

        public IEnumerator Rotate(PlayerRotation rotation)
        {
            if (walkAnim != null)
            {
                yield return StartCoroutine(walkAnim.PlayRoutine(this, new PlayerLocation()
                {
                    Position = CurrentLocation.Position,
                    Rotation = rotation
                }));
            }
            _currentLocation.Rotation = rotation;
            _transform.eulerAngles = Vector3.up * (float)rotation;
        }

        public IEnumerator Jump(Vector3 position)
        {
            if (jumpAnim != null)
            {
                yield return StartCoroutine(walkAnim.PlayRoutine(this, new PlayerLocation()
                {
                    Position = position,
                    Rotation = CurrentLocation.Rotation
                }));
            }
            _currentLocation.Position = position;
            _transform.position = position;
        }
    }
}