using UnityEngine;

namespace LightbotHour.LevelService.Application
{
    internal class CubeItem : MonoBehaviour
    {
        [SerializeField] private CubeLight light;
        public CubeLight Light => light;
        public bool HasLight { get; private set; }
        public void UpdateState(bool hasLight)
        {
            HasLight = hasLight;
            light.gameObject.SetActive(hasLight);
        }

        public void TurnOnLight()
        {
            if (HasLight == false)
            {
                return;
            }

            light.IsOn = true;
        }

        public void TurnOffLight()
        {
            if (HasLight == false)
            {
                return;
            }

            light.IsOn = false;
        }
    }
}