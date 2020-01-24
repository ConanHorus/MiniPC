using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Multiply.
  /// </summary>
  public class Multiply
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Multiply"/> class.
    /// </summary>
    public Multiply()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU2),
          new Calculator(ALUCalculation.Multiply),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}