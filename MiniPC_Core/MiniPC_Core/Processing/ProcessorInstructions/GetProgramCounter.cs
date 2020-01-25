using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Gets program counter.
  /// </summary>
  public class GetProgramCounter
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetProgramCounter"/> class.
    /// </summary>
    public GetProgramCounter()
      : base(new DataMover(DataLocationEnum.ProgramCounter, DataLocationEnum.Register1))
    {
    }
  }
}