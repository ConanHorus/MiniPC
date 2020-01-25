using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Sets program counter.
  /// </summary>
  public class SetProgramCounter
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="SetProgramCounter"/> class.
    /// </summary>
    public SetProgramCounter()
      : base(new DataMover(DataLocationEnum.Register1, DataLocationEnum.ProgramCounter))
    {
    }
  }
}