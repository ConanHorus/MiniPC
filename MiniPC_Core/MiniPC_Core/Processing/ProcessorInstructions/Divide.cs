using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Divide.
  /// </summary>
  public class Divide
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Divide"/> class.
    /// </summary>
    public Divide()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU2),
          new Calculator(ALUCalculation.Divide),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}