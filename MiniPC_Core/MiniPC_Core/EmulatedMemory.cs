using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Core
{
  /// <summary>
  /// Emulated memory.
  /// </summary>
  internal static class EmulatedMemory
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
    /// Number of bytes in an instruction.
    /// </summary>
    public const int INSTRUCTION_LENGTH = WORD_LENGTH;

    /// <summary>
    /// Internal memory.
    /// </summary>
    private static byte[] memory = new byte[MEMORY_SIZE];

    /// <summary>
    /// Location of program counter.
    /// </summary>
    private static ushort pcLocation = 0;

    /// <summary>
    /// Gets next instruction.
    /// </summary>
    /// <returns>Instruction.</returns>
    public static uint GetNextInstruction()
    {
      return GetWord(pcLocation += INSTRUCTION_LENGTH);
    }

    /// <summary>
    /// Gets a double word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    public static ulong GetDoubleWord(ushort address)
    {
      return BufferMarshal.GetFromBuffer(memory, address, DOUBLEWORD_LENGTH);
    }

    /// <summary>
    /// Sets a double word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    public static void SetDoubleWord(ulong value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, memory, address, DOUBLEWORD_LENGTH);
    }

    /// <summary>
    /// Gets a word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    public static uint GetWord(ushort address)
    {
      return (uint)BufferMarshal.GetFromBuffer(memory, address, WORD_LENGTH);
    }

    /// <summary>
    /// Sets a word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    public static void SetWord(uint value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, memory, address, WORD_LENGTH);
    }

    /// <summary>
    /// Gets a half word.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    public static ushort GetHalfWord(ushort address)
    {
      return (ushort)BufferMarshal.GetFromBuffer(memory, address, HALFWORD_LENGTH);
    }

    /// <summary>
    /// Sets a half word.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    public static void SetHalfWord(ushort value, ushort address)
    {
      BufferMarshal.SetInBuffer(value, memory, address, HALFWORD_LENGTH);
    }

    /// <summary>
    /// Gets a byte.
    /// </summary>
    /// <param name="address">Address of value.</param>
    /// <returns>Value.</returns>
    public static byte GetByte(ushort address)
    {
      return memory[address];
    }

    /// <summary>
    /// Sets a byte.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="address">Address to store value.</param>
    public static void SetByte(byte value, ushort address)
    {
      memory[address] = value;
    }
  }
}