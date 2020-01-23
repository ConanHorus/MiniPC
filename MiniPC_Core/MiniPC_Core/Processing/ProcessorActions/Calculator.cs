using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Calculator.
  /// </summary>
  public class Calculator
    : ProcessorAction
  {
    /// <summary>
    /// Calculation choice.
    /// </summary>
    private readonly ALUCalculation calculation;

    /// <summary>
    /// Initializes a new instance of the <see cref="Calculator"/> class.
    /// </summary>
    /// <param name="calculation">Calculation choice.</param>
    public Calculator(ALUCalculation calculation)
    {
      this.calculation = calculation;
    }

    /// <inheritdoc/>
    public override void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu)
    {
      alu.PerformAction(this.calculation, instruction.Immediate);
    }
  }
}