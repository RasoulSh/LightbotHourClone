using System.Collections.Generic;
using LevelService.Mappers;
using LightbotHour.InventoryService;
using LightbotHour.InventoryService.Abstraction;
using LightbotHour.LevelService.Abstraction;
using LightbotHour.LevelService.Config;
using LightbotHour.LevelService.Entities;
using LightbotHour.LevelService.ValueObjects;
using LightbotHour.ProgramService;
using LightbotHour.ProgramService.Abstraction;
using UnityEngine;

namespace LightbotHour.LevelService.Application
{
    [RequireComponent(typeof(ProgramPresenter))]
    [RequireComponent(typeof(InventoryPresenter))]
    [RequireComponent(typeof(LevelPipeline))]
    internal class LevelManager : MonoBehaviour, ILevelManager
    {
        [SerializeField] LevelConfig levelConfig;
        [SerializeField] private BotAI bot;
        private IProgram _program;
        private InventoryPresenter _inventoryPresenter;
        private LevelPipeline _levelPipeline;
        private IInventory<IExecutable> _inventory;
        public IEnumerable<Level> Levels => levelConfig.Levels;
        public Level CurrentLevel { get; private set; }
        public event ILevelManager.SuccessDelegate OnProgramRunFinished;

        private void Start()
        {
            _program = GetComponent<ProgramPresenter>().Program;
            _inventoryPresenter = GetComponent<InventoryPresenter>();
            _levelPipeline = GetComponent<LevelPipeline>();
            _program.OnRunCompleted += OnProgramRunCompleted;
        }
        
        public void PlayLevel(int levelIndex)
        {
            SetLevel(levelConfig.Levels[levelIndex]);
        }

        public void AddCommand(BotCommands command)
        {
            _program.NewCodeLine(CodeMapper.MapToCode(command, bot));
        }

        public void RemoveCommand(int index)
        {
            _program.RemoveItem(index);
        }

        public void RunProgram()
        {
            _program.Run();
        }

        private void OnProgramRunCompleted(IProgram program)
        {
            var isSuccessful = _levelPipeline.AreAllLightsOn;
            OnProgramRunFinished?.Invoke(isSuccessful);
        }

        public void SetLevel(Level level)
        {
            CurrentLevel = level;
            _inventory = _inventoryPresenter.NewInventory<IExecutable>();
            _program.Clear();
            var availableCodes = CodeMapper.MapToCode(level.availableCommands, bot);
            foreach (var availableCode in availableCodes)
            {
                _inventory.AddItem(availableCode);
            }
            var cubeItems = _levelPipeline.RegenerateLevel(level);
            bot.Initialize(cubeItems, level.initialPlayerPoint, level.initialPlayerRotation);
        }
    }
}