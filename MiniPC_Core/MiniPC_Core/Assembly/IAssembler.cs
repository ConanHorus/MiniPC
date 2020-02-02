using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

namespace MiniPC_Library.Assembly
{
  /// <summary>
  /// Assembler.
  /// </summary>
  public interface IAssembler
  {
    /// <summary>
    /// Seperates code into lines.
    /// </summary>
    /// <param name="code">Code to seperate into lines.</param>
    /// <returns>Seperate lines.</returns>
    IEnumerable<string> SeperateIntoLines(string code);

    /// <summary>
    /// Assembles code into bytes that are ready to be placed into memory.
    /// </summary>
    /// <param name="code">Code to assemble.</param>
    /// <returns>Bytes ready for memory.</returns>
    byte[] Assemble(IEnumerable<string> code);
  }
}