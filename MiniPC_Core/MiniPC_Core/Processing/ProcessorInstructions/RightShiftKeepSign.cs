using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Right shift - keep sign.
  /// </summary>
  public class RightShiftKeepSign
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="RightShiftKeepSign"/> class.
    /// </summary>
    public RightShiftKeepSign()
      : base(
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU1),
          new Calculator(ALUCalculation.ShiftRight),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}