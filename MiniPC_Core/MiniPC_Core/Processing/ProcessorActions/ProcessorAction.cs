using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Processor action.
  /// </summary>
  public abstract class ProcessorAction
  {
    /// <summary>
    /// Performs processor action.
    /// </summary>
    /// <param name="instruction">Parsed instruction.</param>
    /// <param name="memory">Memory.</param>
    /// <param name="state">Processor state.</param>
    /// <param name="alu">ALU.</param>
    public abstract void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu);
  }
}