using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Memory
{
  /// <summary>
  /// Marshals specific data sizes in and out of buffer.
  /// </summary>
  public static class BufferMarshal
  {
    /// <summary>
    /// Gets value from buffer.
    /// </summary>
    /// <param name="array">Byte array.</param>
    /// <param name="offset">Offset.</param>
    /// <param name="length">Number of bytes.</param>
    /// <returns>Value.</returns>
    public static unsafe ulong GetFromBuffer(byte[] array, int offset, int length)
    {
      ulong value = 0;
      fixed (byte* buffer = &array[0])
      {
        byte* from = buffer + offset + (length - 1);
        byte* valuePointer = (byte*)&value;
        byte* to = valuePointer;

        while (length-- > 0)
        {
          *to++ = *from--;
        }
      }

      return value;
    }

    /// <summary>
    /// Sets value in buffer.
    /// </summary>
    /// <param name="value">Value.</param>
    /// <param name="array">Byte array.</param>
    /// <param name="offset">Offset.</param>
    /// <param name="length">Number of bytes.</param>
    public static unsafe void SetInBuffer(ulong value, byte[] array, int offset, int length)
    {
      fixed (byte* buffer = &array[0])
      {
        byte* valuePointer = (byte*)&value;
        byte* from = valuePointer + (length - 1);
        byte* to = buffer + offset;

        while (length-- > 0)
        {
          *to++ = *from--;
        }
      }
    }
  }
}