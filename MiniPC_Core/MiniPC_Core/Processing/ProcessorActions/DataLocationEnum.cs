using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Location enum.
  /// </summary>
  public enum DataLocationEnum
  {
    /// <summary>
    /// Register 1.
    /// </summary>
    Register1,

    /// <summary>
    /// Register 2.
    /// </summary>
    Register2,

    /// <summary>
    /// Memory using immediate address.
    /// </summary>
    Memory,

    /// <summary>
    /// Memory using address in register 1.
    /// </summary>
    MemoryThroughRegister1,

    /// <summary>
    /// Memory using address in register 2.
    /// </summary>
    MemoryThroughRegister2,

    /// <summary>
    /// ALU register 1.
    /// </summary>
    ALU1,

    /// <summary>
    /// ALU register 2.
    /// </summary>
    ALU2,

    /// <summary>
    /// ALU result.
    /// </summary>
    ALUResult,

    /// <summary>
    /// Program counter.
    /// </summary>
    ProgramCounter
  }
}