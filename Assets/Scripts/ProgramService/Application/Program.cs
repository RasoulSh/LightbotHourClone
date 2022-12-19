using System.Collections;
using LightbotHour.ProgramService.Abstraction;
using UnityEngine;

namespace LightbotHour.ProgramService.Application
{
    internal class Program : MonoBehaviour, IProgram
    {
        public event IProgram.ProgramDelegate OnRunCompleted;
        private IProcedure _mainProcedure;
        private Coroutine _runRoutine;

        private void Start()
        {
            _mainProcedure = new Procedure();
        }

        public IExecutable AddCodeLine(IExecutable codeLine)
        {
            _mainProcedure.AddCodeLine(codeLine);
            return codeLine;
        }

        public IProcedure NewProcedure()
        {
            var newProcedure = new Procedure();
            return newProcedure;
        }

        public void RemoveItem(int index)
        {
            _mainProcedure.RemoveCodeLine(index);
        }

        public void Clear() => _mainProcedure.Clear();

        public void Run()
        {
            _runRoutine = StartCoroutine(RunRoutine());
        }

        public void Stop()
        {
            if (_runRoutine == null)
            {
                return;
            }
            StopCoroutine(_runRoutine);
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