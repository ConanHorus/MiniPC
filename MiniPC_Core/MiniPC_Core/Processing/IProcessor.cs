using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// Processor.
  /// </summary>
  public interface IProcessor
  {
    /// <summary>
    /// Performs a CPU cycle.
    /// </summary>
    /// <param name="processorState">Processor state.</param>
    /// <param name="memory">Memory to operate on.</param>
    void PerformCycle(ProcessorState processorState, EmulatedMemory memory);
  }
}