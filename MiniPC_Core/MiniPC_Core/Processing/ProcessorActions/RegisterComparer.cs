using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Register comparer.
  /// </summary>
  public class RegisterComparer
    : ProcessorAction
  {
    /// <inheritdoc/>
    public override void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu)
    {
      long a = state.Registers[instruction.Register1];
      long b = state.Registers[instruction.Register2];

      state.High = a > b;
      state.Equal = a == b;
      state.Low = !state.Low;
    }
  }
}