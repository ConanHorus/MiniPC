using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions.DataLocationBehaviors
{
  /// <summary>
  /// First register behavior.
  /// </summary>
  public class FirstRegisterBehavior
    : IDataLocationStrategy
  {
    /// <inheritdoc/>
    public long GetData(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu)
    {
      return state.Registers[instruction.Register1];
    }

    /// <inheritdoc/>
    public void PutData(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu,
      long value)
    {
      state.Registers[instruction.Register1] = value;
    }
  }
}