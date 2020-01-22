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

    /// <inheritdoc/>
    public byte Opcode { get; private set; }

    /// <inheritdoc/>
    public byte Width
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
    public byte Register1 => throw new NotImplementedException();

    /// <inheritdoc/>
    public byte Register2 => throw new NotImplementedException();

    /// <inheritdoc/>
    public ushort Address => throw new NotImplementedException();

    /// <inheritdoc/>
    public byte Immediate => throw new NotImplementedException();

    /// <inheritdoc/>
    public short Offset => throw new NotImplementedException();

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
  }
}