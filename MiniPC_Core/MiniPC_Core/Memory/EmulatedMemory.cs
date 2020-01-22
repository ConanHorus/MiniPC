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
    /// Internal memory.
    /// </summary>
    private byte[] memory = new byte[MEMORY_SIZE];

    /// <summary>
    /// Location of program counter.
    /// </summary>
    private ushort pcLocation = 0;

    /// <inheritdoc/>
    public ulong GetDoubleWord(ushort address)
    {
      return BufferMarshal.GetFromBuffer(this.memory, address, DOUBLEWORD_LENGTH);
    }

    /// <inheritdoc/>
    public void SetDoubleWord(ulong value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, this.memory, address, DOUBLEWORD_LENGTH);
    }

    /// <inheritdoc/>
    public uint GetWord(ushort address)
    {
      return (uint)BufferMarshal.GetFromBuffer(this.memory, address, WORD_LENGTH);
    }

    /// <inheritdoc/>
    public void SetWord(uint value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, this.memory, address, WORD_LENGTH);
    }

    /// <inheritdoc/>
    public ushort GetHalfWord(ushort address)
    {
      return (ushort)BufferMarshal.GetFromBuffer(this.memory, address, HALFWORD_LENGTH);
    }

    /// <inheritdoc/>
    public void SetHalfWord(ushort value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, this.memory, address, HALFWORD_LENGTH);
    }

    /// <inheritdoc/>
    public byte GetByte(ushort address)
    {
      return this.memory[address];
    }

    /// <inheritdoc/>
    public void SetByte(byte value, ushort address)
    {
      this.memory[address] = value;
    }
  }
}