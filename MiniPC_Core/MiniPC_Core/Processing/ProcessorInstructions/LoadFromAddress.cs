using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Processing.ProcessorActions;

namespace MiniPC_Library.Processing.ProcessorInstructions
{
  /// <summary>
  /// Load value from memory address.
  /// </summary>
  public class LoadFromAddress
    : ProcessorInstructionBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LoadFromAddress"/> class.
    /// </summary>
    public LoadFromAddress()
      : base(
          new DataMover(DataLocationEnum.Memory, DataLocationEnum.Register1))
    {
    }
  }
}