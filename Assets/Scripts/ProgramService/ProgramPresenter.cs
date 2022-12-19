using LightbotHour.ProgramService.Abstraction;
using LightbotHour.ProgramService.Application;
using UnityEngine;

namespace LightbotHour.ProgramService
{
    [RequireComponent(typeof(Program))]
    public class ProgramPresenter : MonoBehaviour
    {
        private Program _program;
        public IProgram Program => _program ??= GetComponent<Program>();
    }
}