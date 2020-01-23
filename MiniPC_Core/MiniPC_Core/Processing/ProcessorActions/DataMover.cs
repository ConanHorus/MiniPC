using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;
using MiniPC_Library.Processing.ProcessorActions.DataLocationBehaviors;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Data mover processor action.
  /// </summary>
  public class DataMover
    : ProcessorAction
  {
    /// <summary>
    /// Data location from.
    /// </summary>
    private readonly IDataLocationStrategy from;

    /// <summary>
    /// Data location to.
    /// </summary>
    private readonly IDataLocationStrategy to;

    /// <summary>
    /// Initializes a new instance of the <see cref="DataMover"/> class.
    /// </summary>
    /// <param name="from">From loaction.</param>
    /// <param name="to">To location.</param>
    public DataMover(DataLocationEnum from, DataLocationEnum to)
    {
      this.from = this.ChooseStrategy(from);
      this.to = this.ChooseStrategy(to);
    }

    /// <inheritdoc/>
    public override void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu)
    {
      long value = this.from.GetData(instruction, memory, state, alu);
      this.to.PutData(instruction, memory, state, alu, value);
    }

    /// <summary>
    /// Chooses a data location strategy.
    /// </summary>
    /// <param name="loc">Location enum.</param>
    /// <returns>Data location.</returns>
    private IDataLocationStrategy ChooseStrategy(DataLocationEnum loc)
    {
      switch (loc)
      {
        case DataLocationEnum.ALU1:
          return new ALUFirstRegisterBehavior();

        case DataLocationEnum.ALU2:
          return new ALUSecondRegisterBehavior();

        case DataLocationEnum.ALUResult:
          return new ALUResultBehavior();

        case DataLocationEnum.Memory:
          return new MemoryBehavior();

        case DataLocationEnum.MemoryThroughRegister1:
          return new MemoryThroughFirstRegisterBehavior();

        case DataLocationEnum.MemoryThroughRegister2:
          return new MemoryThroughSecondRegisterBehavior();

        case DataLocationEnum.ProgramCounter:
          return new ProgramCounterBehavior();

        case DataLocationEnum.Register1:
          return new FirstRegisterBehavior();

        case DataLocationEnum.Register2:
          return new SecondRegisterBehavior();

        default:
          throw new ArgumentException("Location strategy not defined", nameof(loc));
      }
    }
  }
}