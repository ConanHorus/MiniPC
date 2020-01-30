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
    private uint rawInstruction;

    /// <summary>
    /// Width backing field.
    /// </summary>
    private byte _width;

    /// <summary>
    /// Whether width is dirty.
    /// </summary>
    private bool isWidthDirty;

    /// <summary>
    /// Register 1 backing field.
    /// </summary>
    private byte _register1;

    /// <summary>
    /// Whether register 1 is dirty.
    /// </summary>
    private bool isRegister1Dirty;

    /// <summary>
    /// Register 2 backing field.
    /// </summary>
    private byte _register2;

    /// <summary>
    /// Whether register 2 is dirty.
    /// </summary>
    private bool isRegister2Dirty;

    /// <summary>
    /// Address backing field.
    /// </summary>
    private ushort _address;

    /// <summary>
    /// Whether address is dirty.
    /// </summary>
    private bool isAddressDirty;

    /// <summary>
    /// Immediate backing field.
    /// </summary>
    private byte _immediate;

    /// <summary>
    /// Whether immediate is dirty.
    /// </summary>
    private bool isImmediateDirty;

    /// <summary>
    /// Ofset backing field.
    /// </summary>
    private short _offset;

    /// <summary>
    /// Whether offset is dirty.
    /// </summary>
    private bool isOffsetDirty;

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
    public byte Register1
    {
      get
      {
        if (this.isRegister1Dirty)
        {
          this.ExtractRegister1();
        }

        return this._register1;
      }

      private set
      {
        this._register1 = value;
        this.isRegister1Dirty = false;
      }
    }

    /// <inheritdoc/>
    public byte Register2
    {
      get
      {
        if (this.isRegister2Dirty)
        {
          this.ExtractRegister2();
        }

        return this._register2;
      }

      private set
      {
        this._register2 = value;
        this.isRegister2Dirty = false;
      }
    }

    /// <inheritdoc/>
    public ushort Address
    {
      get
      {
        if (this.isAddressDirty)
        {
          this.ExtractAddress();
        }

        return this._address;
      }

      private set
      {
        this._address = value;
        this.isAddressDirty = false;
      }
    }

    /// <inheritdoc/>
    public byte Immediate
    {
      get
      {
        if (this.isImmediateDirty)
        {
          this.ExtractImmediate();
        }

        return this._immediate;
      }

      private set
      {
        this._immediate = value;
        this.isImmediateDirty = false;
      }
    }

    /// <inheritdoc/>
    public short Offset
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
    public void LoadRawInstruction(uint rawInstruction)
    {
      this.rawInstruction = rawInstruction;

      this.isWidthDirty = true;
      this.isRegister1Dirty = true;
      this.isRegister2Dirty = true;
      this.isAddressDirty = true;
      this.isImmediateDirty = true;
      this.isOffsetDirty = true;

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
    /// Extracts register 1 from raw instruction.
    /// </summary>
    private void ExtractRegister1()
    {
      const int REG1_OFFSET = 21;
      const int REG1_MASK = 0b0000_0111;

      this.Register1 = (byte)((this.rawInstruction >> REG1_OFFSET) & REG1_MASK);
    }

    /// <summary>
    /// Extracts register 2 from raw instruction.
    /// </summary>
    private void ExtractRegister2()
    {
      const int REG2_OFFSET = 18;
      const int REG2_MASK = 0b0000_0111;

      this.Register2 = (byte)((this.rawInstruction >> REG2_OFFSET) & REG2_MASK);
    }

    /// <summary>
    /// Extracts address from raw instruction.
    /// </summary>
    private void ExtractAddress()
    {
      this.Address = (ushort)(this.rawInstruction & ushort.MaxValue);
    }

    /// <summary>
    /// Extracts immediate from raw instruction.
    /// </summary>
    private void ExtractImmediate()
    {
      this.Immediate = (byte)(this.rawInstruction & byte.MaxValue);
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