using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// State checker.
  /// </summary>
  public class StateChecker
    : ProcessorAction
  {
    /// <summary>
    /// Check low.
    /// </summary>
    private readonly bool low;

    /// <summary>
    /// Check equal.
    /// </summary>
    private readonly bool equal;

    /// <summary>
    /// Check high.
    /// </summary>
    private readonly bool high;

    /// <summary>
    /// Processor action to perform on state.
    /// </summary>
    private readonly ProcessorAction action;

    /// <summary>
    /// Initializes a new instance of the <see cref="StateChecker"/> class.
    /// </summary>
    /// <param name="low">Check low.</param>
    /// <param name="equal">Check equal.</param>
    /// <param name="high">Check high.</param>
    /// <param name="action">Action to perform on state.</param>
    public StateChecker(bool low, bool equal, bool high, ProcessorAction action)
    {
      this.low = low;
      this.equal = equal;
      this.high = high;
      this.action = action;
    }

    /// <inheritdoc/>
    public override void PerformAction(
      IParsedInstruction instruction,
      IEmulatedMemory memory,
      IProcessorState state,
      IALU alu)
    {
      if (state.Low & this.low || state.Equal & this.equal || state.High & this.high)
      {
        this.action.PerformAction(instruction, memory, state, alu);
      }
    }
  }
}