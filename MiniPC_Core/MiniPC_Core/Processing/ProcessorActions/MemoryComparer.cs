using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Memory comparer.
  /// </summary>
  public class MemoryComparer
    : ProcessorAction
  {
    /// <inheritdoc/>
    public override void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu)
    {
      ushort addressA = (ushort)state.Registers[instruction.Register1];
      ushort addressB = (ushort)state.Registers[instruction.Register2];

      byte a = 0;
      byte b = 0;
      for (ushort i = 0; i < instruction.Immediate; i++)
      {
        a = memory.GetByte((ushort)(addressA + i));
        b = memory.GetByte((ushort)(addressB + i));

        if (a != b)
        {
          break;
        }
      }

      state.High = a > b;
      state.Equal = a == b;
      state.Low = !state.High;
    }
  }
}