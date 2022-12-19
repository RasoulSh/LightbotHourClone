using System.Collections.Generic;
using System.Linq;
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
        private IProcedure _procedure1;

        private void Start()
        {
            _program = GetComponent<ProgramPresenter>().Program;
            _inventoryPresenter = GetComponent<InventoryPresenter>();
            _levelPipeline = GetComponent<LevelPipeline>();
            _procedure1 = _program.NewProcedure();
            _program.OnRunCompleted += OnProgramRunCompleted;
        }
        
        public void PlayLevel(int levelIndex)
        {
            SetLevel(levelConfig.Levels[levelIndex]);
        }

        public void AddCommand(BotCommands command)
        {
            _program.AddCodeLine(GetCodeLine(command));
        }

        public void RemoveCommand(int index)
        {
            _program.RemoveItem(index);
        }

        public void AddCommandToProcedure1(BotCommands command)
        {
            _procedure1.AddCodeLine(GetCodeLine(command));
        }

        public void RemoveCommandFromProcedure1(int index)
        {
            _procedure1.RemoveCodeLine(index);
        }

        public void RunProgram()
        {
            _program.Run();
        }
        
        public void StopProgram()
        {
            _program.Stop();
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
            _procedure1.Clear();
            var availableCodes = CodeMapper.MapToCode(level.availableCommands, bot);
            foreach (var availableCode in availableCodes)
            {
                _inventory.AddItem(availableCode);
            }
            var cubeItems = _levelPipeline.RegenerateLevel(level);
            bot.Initialize(cubeItems, level.initialPlayerPoint, level.initialPlayerRotation);
        }

        private IExecutable GetCodeLine(BotCommands command)
        {
            IExecutable codeLine;
            if (command == BotCommands.Proc1)
            {
                codeLine = _procedure1;
            }
            else
            {
                codeLine = CodeMapper.MapToCode(command, bot);
            }

            return codeLine;
        }
    }
}