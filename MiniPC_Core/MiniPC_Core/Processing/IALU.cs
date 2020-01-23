using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// ALU.
  /// </summary>
  public interface IALU
  {
    /// <summary>
    /// Stages value on ALU register.
    /// </summary>
    /// <param name="register">Register 0 or 1.</param>
    /// <param name="value">Value to stage.</param>
    void StageValue(int register, long value);

    /// <summary>
    /// Reads result.
    /// </summary>
    /// <returns>Result value.</returns>
    long ReadResult();

    /// <summary>
    /// Performs calculation.
    /// </summary>
    /// <param name="calculation">Calculation choice.</param>
    void PerformAction(ALUCalculation calculation);

    /// <summary>
    /// Performs calculation.
    /// </summary>
    /// <param name="calculation">Calculation choice.</param>
    /// <param name="value">Augmenting value.</param>
    void PerformAction(ALUCalculation calculation, int value);
  }
}