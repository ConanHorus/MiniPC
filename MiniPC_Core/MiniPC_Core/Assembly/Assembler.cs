using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MiniPC_Library.Assembly
{
  /// <inheritdoc/>
  public class Assembler
    : IAssembler
  {
    /// <inheritdoc/>
    public byte[] Assemble(IEnumerable<string> code)
    {
      throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public IEnumerable<string> SeperateIntoLines(string code)
    {
      return this.SeperateIntoLinesHelper(code).Where(x => !(x is null));
    }

    /// <summary>
    /// Seperates code into individual lines - blank lines are null.
    /// </summary>
    /// <param name="code">Code to break into lines.</param>
    /// <returns>Collection of lines.</returns>
    private IEnumerable<string> SeperateIntoLinesHelper(string code)
    {
      if (string.IsNullOrWhiteSpace(code))
      {
        yield break;
      }

      int start = 0;
      int length = 0;
      int index = 0;
      foreach (char c in code)
      {
        index++;
        if (c == '\n' || c == '\r')
        {
          yield return this.GenerateLine(code, start, length);
          length = 0;
          start = index;
          continue;
        }

        length++;
      }

      yield return this.GenerateLine(code, start, length);
    }

    /// <summary>
    /// Generates and returns line from code.
    /// </summary>
    /// <param name="code">Code to break into lines.</param>
    /// <param name="start">Start of line in code.</param>
    /// <param name="length">Length of line in code.</param>
    /// <returns>Line.</returns>
    private unsafe string GenerateLine(string code, int start, int length)
    {
      if (length == 0)
      {
        return null;
      }

      fixed (char* ptr = code)
      {
        return new string(ptr, start, length);
      }
    }
  }
}