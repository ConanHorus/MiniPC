using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions.DataLocationBehaviors
{
  /// <summary>
  /// Memory through first register behavior.
  /// </summary>
  public class MemoryThroughFirstRegisterBehavior
    : IDataLocationStrategy
  {
    /// <inheritdoc/>
    public long GetData(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu)
    {
      return (long)memory.GetDoubleWord((ushort)state.Registers[instruction.Register1]);
    }

    /// <inheritdoc/>
    public void PutData(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu,
      long value)
    {
      memory.SetDoubleWord((ulong)value, (ushort)state.Registers[instruction.Register1]);
    }
  }
}