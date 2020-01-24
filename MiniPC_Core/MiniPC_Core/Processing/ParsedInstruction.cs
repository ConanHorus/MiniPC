using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <inheritdoc/>
  public class ParsedInstruction
    : IParsedInstruction
  {
    /// <summary>
    /// Raw instruction.
    /// </summary>
    private ulong rawInstruction;

    /// <summary>
    /// Width backing field.
    /// </summary>
    private byte _width;

    /// <summary>
    /// Whether width is dirty.
    /// </summary>
    private bool isWidthDirty = true;

    /// <summary>
    /// Ofset backing field.
    /// </summary>
    private short _offset;

    /// <summary>
    /// Whether offset is dirty.
    /// </summary>
    private bool isOffsetDirty = true;

    /// <inheritdoc/>
    public byte Opcode { get; private set; } // todo unit test

    /// <inheritdoc/>
    public byte Width // todo unit test
    {
      get
      {
        if (this.isWidthDirty)
        {
          this.ExtractWidth();
        }

        return this._width;
      }

      private set
      {
        this._width = value;
        this.isWidthDirty = false;
      }
    }

    /// <inheritdoc/>
    public byte Register1 => throw new NotImplementedException(); // todo unit test

    /// <inheritdoc/>
    public byte Register2 => throw new NotImplementedException(); // todo unit test

    /// <inheritdoc/>
    public ushort Address => throw new NotImplementedException(); // todo unit test

    /// <inheritdoc/>
    public byte Immediate => throw new NotImplementedException(); // todo unit test

    /// <inheritdoc/>
    public short Offset // todo unit test
    {
      get
      {
        if (this.isOffsetDirty)
        {
          this.ExtractOffset();
        }

        return this._offset;
      }

      private set
      {
        this._offset = value;
        this.isOffsetDirty = false;
      }
    }

    /// <inheritdoc/>
    public void LoadRawInstruction(ulong rawInstruction)
    {
      this.rawInstruction = rawInstruction;

      this.isWidthDirty = false;

      this.ExtractOpcode();
    }

    /// <summary>
    /// Extracts opcode from raw instruction.
    /// </summary>
    private void ExtractOpcode()
    {
      const int OPCODE_SHIFT = 26;
      const byte OPCODE_MASK = 0b0011_1111;

      this.Opcode = (byte)((this.rawInstruction >> OPCODE_SHIFT) & OPCODE_MASK);
    }

    /// <summary>
    /// Extracts width from raw instruction.
    /// </summary>
    private void ExtractWidth()
    {
      const int WIDTH_SHIFT = 24;
      const byte WIDTH_MASK = 0b0000_0011;

      this.Width = (byte)((this.rawInstruction >> WIDTH_SHIFT) & WIDTH_MASK);
    }

    /// <summary>
    /// Extracts offset from raw instruction.
    /// </summary>
    private void ExtractOffset()
    {
      const int EXTEND_FLAG = 0xFF_00;
      const byte NEGATIVE_CHECK = 0b1000_0000;
      const byte OFFSET_MASK = 0b1111_1111;

      byte b = (byte)(this.rawInstruction & OFFSET_MASK);

      int value = b;
      if (b >= NEGATIVE_CHECK)
      {
        value |= EXTEND_FLAG;
      }

      this.Offset = (short)value;
    }
  }
}