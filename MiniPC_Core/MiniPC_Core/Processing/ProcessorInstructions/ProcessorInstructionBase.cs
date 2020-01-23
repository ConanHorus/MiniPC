using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Processor instruction.
  /// </summary>
  public abstract class ProcessorInstructionBase
  {
    /// <summary>
    /// Collection of processor actions.
    /// </summary>
    private readonly ProcessorAction[] actions;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessorInstructionBase"/> class.
    /// </summary>
    /// <param name="actions">Collection of actions.</param>
    public ProcessorInstructionBase(params ProcessorAction[] actions)
    {
      this.actions = actions;
    }

    /// <summary>
    /// Performs actions.
    /// </summary>
    /// <param name="instruction">Parsed instruction.</param>
    /// <param name="memory">Memory.</param>
    /// <param name="state">Processor state.</param>
    /// <param name="alu">ALU.</param>
    public void PerformActions(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu)
    {
      foreach (var action in this.actions)
      {
        action.PerformAction(instruction, memory, state, alu);
      }
    }
  }
}