using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions.DataLocationBehaviors
{
  /// <summary>
  /// Address behavior.
  /// </summary>
  public class AddressBehavior
    : IDataLocationStrategy
  {
    /// <inheritdoc/>
    public long GetData(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu)
    {
      return instruction.Address;
    }

    /// <inheritdoc/>
    public void PutData(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu,
      long value)
    {
      throw new NotImplementedException();
    }
  }
}