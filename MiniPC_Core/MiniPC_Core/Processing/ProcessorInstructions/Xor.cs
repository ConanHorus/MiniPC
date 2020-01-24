using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Xor.
  /// </summary>
  public class Xor
    : ProcessorInstructionBase
  {
    public Xor()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.ALU1),
          new DataMover(DataLocationEnum.Register2, DataLocationEnum.ALU2),
          new Calculator(ALUCalculation.Xor),
          new DataMover(DataLocationEnum.ALUResult, DataLocationEnum.Register1))
    {
    }
  }
}