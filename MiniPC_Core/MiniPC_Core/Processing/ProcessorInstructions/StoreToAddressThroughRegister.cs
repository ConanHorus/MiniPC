using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Store to address through register.
  /// </summary>
  public class StoreToAddressThroughRegister
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StoreToAddressThroughRegister"/> class.
    /// </summary>
    public StoreToAddressThroughRegister()
      : base(
          new DataMover(DataLocationEnum.Register1, DataLocationEnum.MemoryThroughRegister2))
    {
    }
  }
}