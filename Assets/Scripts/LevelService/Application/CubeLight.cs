using System;
using UnityEngine;

namespace LightbotHour.LevelService.Application
{
    public class CubeLight : MonoBehaviour
    {
        [SerializeField] private GameObject offLight;
        [SerializeField] private GameObject onLight;
        private bool _isOn;

        public bool IsOn
        {
            get => _isOn;
            set
            {
                _isOn = value;
                offLight.SetActive(_isOn == false);
                onLight.SetActive(_isOn);
            }
        }

        private void Start()
        {
            IsOn = false;
        }
    }
}