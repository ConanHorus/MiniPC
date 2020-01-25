using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Branch.
  /// </summary>
  public class Branch
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Branch"/> class.
    /// </summary>
    /// <param name="low">Low.</param>
    /// <param name="equal">Equal.</param>
    /// <param name="high">High.</param>
    public Branch(bool low, bool equal, bool high)
      : base(
          new StateChecker(low, equal, high, new DataMover(DataLocationEnum.Register1, DataLocationEnum.ProgramCounter)))
    {
    }
  }
}