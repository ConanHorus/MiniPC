using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Memory
{
  /// <inheritdoc/>
  public class EmulatedMemory
    : IEmulatedMemory
  {
    /// <summary>
    /// Size of memory buffer.
    /// </summary>
    public const int MEMORY_SIZE = ushort.MaxValue;

    /// <summary>
    /// Size of double word in bytes.
    /// </summary>
    public const int DOUBLEWORD_LENGTH = 8;

    /// <summary>
    /// Size of word in bytes.
    /// </summary>
    public const int WORD_LENGTH = 4;

    /// <summary>
    /// Size of halfword in bytes.
    /// </summary>
    public const int HALFWORD_LENGTH = 2;

    /// <summary>
    /// Size of a byte in bytes.
    /// </summary>
    public const int BYTE_LENGTH = 1;

    /// <summary>
    /// Internal memory.
    /// </summary>
    private readonly byte[] memory = new byte[MEMORY_SIZE];

    /// <inheritdoc/>
    public ulong GetValue(byte width, ushort address)
    {
      return BufferMarshal.GetFromBuffer(this.memory, address, this.ConvertWidth(width));
    }

    /// <inheritdoc/>
    public void SetValue(byte width, ulong value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, this.memory, address, this.ConvertWidth(width));
    }

    /// <summary>
    /// Converts raw width to number of bytes.
    /// </summary>
    /// <param name="width">Width from instruction.</param>
    /// <returns>Number of bytes.</returns>
    private int ConvertWidth(byte width)
    {
      const int WIDTH_BITS = 0b0000_0011;

      switch (width & WIDTH_BITS)
      {
        default:
        case 0:
          return BYTE_LENGTH;

        case 1:
          return HALFWORD_LENGTH;

        case 2:
          return WORD_LENGTH;

        case 3:
          return DOUBLEWORD_LENGTH;
      }
    }
  }
}