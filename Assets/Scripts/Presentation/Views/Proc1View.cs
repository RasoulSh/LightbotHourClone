using LightbotHour.Common.Extensions;
using LightbotHour.Common.GUIPanelSystem;
using LightbotHour.LevelInteractor;
using LightbotHour.LevelInteractor.Abstraction;
using LightbotHour.LevelInteractor.ValueObject;
using Presentation.GUI.ProgramGUI;
using UnityEngine;
using UnityEngine.UI;

namespace LightbotHour.Presentation.Views
{
    public class Proc1View : ProcedureView
    {
        protected override void AddCommand(BotCommandValue command)
        {
            programController.AddCommandToProcedure1(command);
        }

        protected override void RemoveCommand(int index)
        {
            programController.RemoveCommandFromProcedure1(index);
        }
    }
}