using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Load from address through register.
  /// </summary>
  public class LoadFromAddressThroughRegister
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LoadFromAddressThroughRegister"/> class.
    /// </summary>
    public LoadFromAddressThroughRegister()
      : base(
          new DataMover(DataLocationEnum.MemoryThroughRegister2, DataLocationEnum.Register1))
    {
    }
  }
}