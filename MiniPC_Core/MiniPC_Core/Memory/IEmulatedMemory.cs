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
    /// Gets a double word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    ulong GetDoubleWord(ushort address);

    /// <summary>
    /// Sets a double word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    void SetDoubleWord(ulong value, ushort address);

    /// <summary>
    /// Gets a word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    uint GetWord(ushort address);

    /// <summary>
    /// Sets a word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    void SetWord(uint value, ushort address);

    /// <summary>
    /// Gets a half word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    ushort GetHalfWord(ushort address);

    /// <summary>
    /// Sets a half word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    void SetHalfWord(ushort value, ushort address);

    /// <summary>
    /// Gets a byte.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    byte GetByte(ushort address);

    /// <summary>
    /// Sets a byte.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    void SetByte(byte value, ushort address);
  }
}