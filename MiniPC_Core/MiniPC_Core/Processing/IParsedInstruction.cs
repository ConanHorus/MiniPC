using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <summary>
  /// Parsed isntruction.
  /// </summary>
  public interface IParsedInstruction
  {
    /// <summary>
    /// Gets opcode.
    /// </summary>
    byte Opcode { get; }

    /// <summary>
    /// Gets width.
    /// </summary>
    byte Width { get; }

    /// <summary>
    /// Gets first register.
    /// </summary>
    byte Register1 { get; }

    /// <summary>
    /// Gets second register.
    /// </summary>
    byte Register2 { get; }

    /// <summary>
    /// Gets address.
    /// </summary>
    ushort Address { get; }

    /// <summary>
    /// Gets immediate value.
    /// </summary>
    byte Immediate { get; }

    /// <summary>
    /// Gets offset.
    /// </summary>
    short Offset { get; }

    /// <summary>
    /// Loads raw instruction.
    /// </summary>
    /// <param name="rawInstruction">Raw instruction.</param>
    void LoadRawInstruction(ulong rawInstruction);
  }
}