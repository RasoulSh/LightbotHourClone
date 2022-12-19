using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LightbotHour.ProgramService.Abstraction;

namespace LightbotHour.ProgramService.Application
{
    internal class Procedure : IProcedure
    {
        public IEnumerable<IExecutable> CodeLines { get; private set; }
        public event IExecutable.ExecutableDelegate OnCodeAdded;
        public event IExecutable.ExecutableDelegate OnCodeRemoved;
        public event IProcedure.ProcedureDelegate OnCleared;
        private IList<IExecutable> codeLines;

        public IEnumerable<IEnumerator> ExecuteRoutines => codeLines.SelectMany(
            codeLine => codeLine.ExecuteRoutines);

        public Procedure()
        {
            codeLines = new List<IExecutable>();
        }

        public void AddCodeLine(IExecutable codeLine)
        {
            codeLines.Add(codeLine);
            OnCodeAdded?.Invoke(codeLine);
        }
        
        public void RemoveCodeLine(int index) => RemoveCodeLine(codeLines[index]);

        public void RemoveCodeLine(IExecutable codeLine)
        {
            codeLines.Remove(codeLine);
            OnCodeRemoved?.Invoke(codeLine);
        }

        public void Clear()
        {
            codeLines.Clear();
            OnCleared?.Invoke(this);
        }
    }
   
}