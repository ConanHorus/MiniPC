using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <inheritdoc/>
  public class ProcessorState
    : IProcessorState
  {
    /// <summary>
    /// Number of registers.
    /// </summary>
    public const int REGISTER_COUNT = 8;

    /// <inheritdoc/>
    public ushort ProgramCounter { get; set; }

    /// <inheritdoc/>
    public bool Low { get; set; }

    /// <inheritdoc/>
    public bool Equal { get; set; }

    /// <inheritdoc/>
    public bool High { get; set; }

    /// <inheritdoc/>
    public long[] Registers { get; } = new long[REGISTER_COUNT];

    /// <inheritdoc/>
    public bool Halted { get; set; }

    /// <inheritdoc/>
    public bool Running { get; set; }
  }
}