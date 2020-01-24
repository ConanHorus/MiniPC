using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Not.
  /// </summary>
  public class Not
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Not"/> class.
    /// </summary>
    public Not()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new Calculator(ALUCalculation.Not),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}