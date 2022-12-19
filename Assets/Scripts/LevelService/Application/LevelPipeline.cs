using System.Collections.Generic;
using System.Linq;
using LightbotHour.LevelService.Entities;
using UnityEngine;

namespace LightbotHour.LevelService.Application
{
    internal class LevelPipeline : MonoBehaviour
    {
        [SerializeField] private CubeItem cubeItemPrefab;
        [SerializeField] private float cubeSize = 1f;
        [SerializeField] private Transform worldStartPoint;
        private Dictionary<Cube, CubeItem> _currentCubeItems;
        public float CubeSize => cubeSize;

        public Dictionary<Cube, CubeItem> RegenerateLevel(Level level)
        {
            if (_currentCubeItems != null)
            {
                _currentCubeItems.Values.ToList().
                    ForEach(cubeItem => Destroy(cubeItem.gameObject));
            }

            _currentCubeItems = new Dictionary<Cube, CubeItem>();
            foreach (var cube in level.cubes)
            {
                _currentCubeItems.Add(cube, GenerateCubeItem(cube));
            }
            return _currentCubeItems;
        }

        private CubeItem GenerateCubeItem(Cube cube)
        {
            var newCubeItem = Instantiate(cubeItemPrefab);
            newCubeItem.UpdateState(cube.hasLight);
            var cubeTransform = newCubeItem.transform;
            cubeTransform.position = GetCubePosition(cube.point);
            return newCubeItem;
        }

        public Vector3 GetCubeTopPosition(Vector3Int point)
        {
            return GetCubePosition(point) + cubeSize * Vector3.up;
        }

        public Vector3 GetCubePosition(Vector3Int point)
        {
            return worldStartPoint.position + cubeSize * (Vector3)point;
        }

        public bool AreAllLightsOn
        {
            get
            {
                return _currentCubeItems.Values.All(cubeItem => cubeItem.HasLight == false ||
                                                                cubeItem.Light.IsOn);
            }
        }
    }
}