using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// Processor state.
  /// </summary>
  public interface IProcessorState
  {
    /// <summary>
    /// Gets or sets program counter.
    /// </summary>
    ushort ProgramCounter { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded a low condition.
    /// </summary>
    bool Low { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded an equal condition.
    /// </summary>
    bool Equal { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded a high condition.
    /// </summary>
    bool High { get; set; }

    /// <summary>
    /// Gets collection of registers.
    /// </summary>
    long[] Registers { get; }

    /// <summary>
    /// Gets or sets a value indicating whether processor is halted.
    /// </summary>
    bool Halted { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether processor is running.
    /// </summary>
    bool Running { get; set; }
  }
}