using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.Mappers;
using LightbotHour.LevelInteractor.ValueObject;
using LightbotHour.LevelService;
using LightbotHour.LevelService.Abstraction;
using UnityEngine;

namespace LightbotHour.LevelInteractor.Controllers
{
    [RequireComponent(typeof(LevelPresenter))]
    internal class ProgramController : MonoBehaviour, IProgramController
    {
        public event IProgramController.SuccessDelegate OnProgramRunFinished;
        private ILevelManager _levelManager;
        
        private void Start()
        {
            _levelManager = GetComponent<LevelPresenter>().LevelManager;
            _levelManager.OnProgramRunFinished += OnProgramRunCompleted;
        }

        private void OnProgramRunCompleted(bool isSuccessful)
        {
            OnProgramRunFinished?.Invoke(isSuccessful);
        }

        public void RunProgram()
        {
            _levelManager.RunProgram();
        }
        
        public void StopProgram()
        {
            _levelManager.StopProgram();
        }

        public void AddCommand(BotCommandValue command)
        {
            _levelManager.AddCommand(CommandValueMapper.MapToBotCommand(command));
        }

        public void RemoveCommand(int index)
        {
            _levelManager.RemoveCommand(index);
        }

        public void AddCommandToProcedure1(BotCommandValue command)
        {
            _levelManager.AddCommandToProcedure1(CommandValueMapper.MapToBotCommand(command));
        }
        
        public void RemoveCommandFromProcedure1(int index)
        {
            _levelManager.RemoveCommandFromProcedure1(index);
        }
    }
}