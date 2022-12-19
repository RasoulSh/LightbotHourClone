using System.Collections.Generic;

namespace LightbotHour.ProgramService.Abstraction
{
    public interface IProcedure : IExecutable
    {
        IEnumerable<IExecutable> CodeLines { get; }
        event ExecutableDelegate OnCodeAdded;
        event ExecutableDelegate OnCodeRemoved;
        event ProcedureDelegate OnCleared;
        void AddCodeLine(IExecutable codeLine);
        void RemoveCodeLine(IExecutable codeLine);
        void RemoveCodeLine(int index);
        void Clear();
        delegate void ProcedureDelegate(IProcedure procedure);
    }
}