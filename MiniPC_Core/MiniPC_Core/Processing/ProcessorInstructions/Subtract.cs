using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Subtract.
  /// </summary>
  public class Subtract
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Subtract"/> class.
    /// </summary>
    public Subtract()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU2),
          new Calculator(ALUCalculation.Subtract),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}