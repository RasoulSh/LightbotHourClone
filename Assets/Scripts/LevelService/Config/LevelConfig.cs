using System;
using System.Collections.Generic;
using LightbotHour.LevelService.Entities;
using UnityEngine;

namespace LightbotHour.LevelService.Config
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<Level> levels;
        public IList<Level> Levels => levels;
    }
}