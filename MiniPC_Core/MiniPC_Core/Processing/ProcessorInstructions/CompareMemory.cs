using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Compare memory.
  /// </summary>
  public class CompareMemory
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CompareMemory"/> class.
    /// </summary>
    public CompareMemory()
      : base(new MemoryComparer())
    {
    }
  }
}