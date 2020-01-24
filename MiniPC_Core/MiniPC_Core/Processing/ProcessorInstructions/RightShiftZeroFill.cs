using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Right shift - zero fill.
  /// </summary>
  public class RightShiftZeroFill
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RightShiftZeroFill"/> class.
    /// </summary>
    public RightShiftZeroFill()
      : base(
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU1),
          new Calculator(ALUCalculation.ShiftRightZeroFill),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}