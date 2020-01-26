using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Store to address.
  /// </summary>
  public class StoreToAddress
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StoreToAddress"/> class.
    /// </summary>
    public StoreToAddress()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.Address))
    {
    }
  }
}