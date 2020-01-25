using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Compare registers.
  /// </summary>
  public class CompareRegisters
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CompareRegisters"/> class.
    /// </summary>
    public CompareRegisters()
      : base(new RegisterComparer())
    {
    }
  }
}