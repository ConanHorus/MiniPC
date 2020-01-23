using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Left shift instruction.
  /// </summary>
  public class LeftShift
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LeftShift"/> class.
    /// </summary>
    public LeftShift()
      : base(
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU1),
          new Calculator(ALUCalculation.ShiftLeft),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}