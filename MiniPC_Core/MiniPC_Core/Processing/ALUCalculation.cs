using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// Calculation choices.
  /// </summary>
  public enum ALUCalculation
  {
    /// <summary>
    /// Shift left.
    /// </summary>
    ShiftLeft,

    /// <summary>
    /// Shift right.
    /// </summary>
    ShiftRight,

    /// <summary>
    /// Shift right with zero fill.
    /// </summary>
    ShiftRightZeroFill,

    /// <summary>
    /// Add.
    /// </summary>
    Add,

    /// <summary>
    /// Subtract.
    /// </summary>
    Subtract,

    /// <summary>
    /// Multiply.
    /// </summary>
    Multiply,

    /// <summary>
    /// Divide.
    /// </summary>
    Divide,

    /// <summary>
    /// Not.
    /// </summary>
    Not,

    /// <summary>
    /// And.
    /// </summary>
    And,

    /// <summary>
    /// Xor.
    /// </summary>
    Xor
  }
}