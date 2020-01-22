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
    void PerformCycle();
  }
}