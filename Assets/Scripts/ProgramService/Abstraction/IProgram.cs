using System.Collections.Generic;

namespace LightbotHour.ProgramService.Abstraction
{
    public interface IProgram
    {
        event ProgramDelegate OnRunCompleted;
        delegate void ProgramDelegate(IProgram program);
        IExecutable AddCodeLine(IExecutable codeLine);
        IProcedure NewProcedure();
        void RemoveItem(int index);
        void Clear();
        void Run();
        void Stop();
    }
}