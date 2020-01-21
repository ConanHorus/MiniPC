using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// Processor state.
  /// </summary>
  public class ProcessorState
  {
    /// <summary>
    /// Number of registers.
    /// </summary>
    public const int REGISTER_COUNT = 8;

    /// <summary>
    /// Gets or sets program counter.
    /// </summary>
    public ushort ProgramCounter { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded a low condition.
    /// </summary>
    public bool Low { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded an equal condition.
    /// </summary>
    public bool Equal { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether last comparison yielded a high condition.
    /// </summary>
    public bool High { get; set; }

    /// <summary>
    /// Gets collection of registers.
    /// </summary>
    public long[] Registers { get; } = new long[REGISTER_COUNT];
  }
}