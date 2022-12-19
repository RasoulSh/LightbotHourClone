using System.Collections;
using LightbotHour.ProgramService.Abstraction;
using UnityEngine;

namespace LightbotHour.ProgramService.Application
{
    internal class Program : MonoBehaviour, IProgram
    {
        public event IProgram.ProgramDelegate OnRunCompleted;
        private IProcedure _mainProcedure;

        private void Start()
        {
            _mainProcedure = new Procedure();
        }

        public IExecutable NewCodeLine(IExecutable codeLine)
        {
            _mainProcedure.AddCodeLine(codeLine);
            return codeLine;
        }

        public IProcedure NewProcedure()
        {
            var newProcedure = new Procedure();
            _mainProcedure.AddCodeLine(newProcedure);
            return newProcedure;
        }

        public void RemoveItem(int index)
        {
            _mainProcedure.RemoveCodeLine(index);
        }

        public void Clear() => _mainProcedure.Clear();

        public void Run()
        {
            StartCoroutine(RunRoutine());
        }

        private IEnumerator RunRoutine()
        {
            foreach (var executeRoutine in _mainProcedure.ExecuteRoutines)
            {
                yield return StartCoroutine(executeRoutine);
            }
            OnRunCompleted?.Invoke(this);
        }
    }
}