using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Memory
{
  /// <summary>
  /// Emulated memory.
  /// </summary>
  public interface IEmulatedMemory
  {
    /// <summary>
    /// Gets value in memory.
    /// </summary>
    /// <param name="width">Width of value.</param>
    /// <param name="address">Address to get value.</param>
    /// <returns>Value.</returns>
    ulong GetValue(byte width, ushort address);

    /// <summary>
    /// Sets value in memory.
    /// </summary>
    /// <param name="width">Width of value.</param>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    void SetValue(byte width, ulong value, ushort address);
  }
}