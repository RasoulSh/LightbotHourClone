using System.Collections;
using System.Collections.Generic;

namespace LightbotHour.ProgramService.Abstraction
{
    public interface IExecutable
    {
        IEnumerable<IEnumerator> ExecuteRoutines { get; }
        delegate void ExecutableDelegate(IExecutable executable);
    }
}