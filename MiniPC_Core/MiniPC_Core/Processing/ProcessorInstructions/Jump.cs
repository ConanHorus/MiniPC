using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Jump.
  /// </summary>
  public class Jump
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Jump"/> class.
    /// </summary>
    /// <param name="low">Low.</param>
    /// <param name="equal">Equal.</param>
    /// <param name="high">High.</param>
    public Jump(bool low, bool equal, bool high)
      : base(
          new StateChecker(low, equal, high, new DataMover(DataLocationEnum.Address, DataLocationEnum.ProgramCounter)))
    {
    }
  }
}