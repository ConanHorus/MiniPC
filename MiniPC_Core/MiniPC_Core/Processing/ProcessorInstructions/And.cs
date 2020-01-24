using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// And.
  /// </summary>
  public class And
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="And"/> class.
    /// </summary>
    public And()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU2),
          new Calculator(ALUCalculation.And),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}