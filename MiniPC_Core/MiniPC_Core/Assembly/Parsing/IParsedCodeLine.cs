using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Assembly.Parsing
{
  /// <summary>
  /// Parsed code line.
  /// </summary>
  internal interface IParsedCodeLine
  {
    /// <summary>
    /// Gets or sets label.
    /// </summary>
    string Label { get; set; }

    /// <summary>
    /// Sets address (right-hand of instruction).
    /// </summary>
    /// <param name="address">Address.</param>
    void SetAddress(ushort address);

    /// <summary>
    /// Sets value (right-hand of instruction).
    /// </summary>
    /// <param name="value">Value.</param>
    void SetValue(byte value);

    /// <summary>
    /// Sets instruction opcode.
    /// </summary>
    /// <param name="opcode">OLpcode.</param>
    void SetOpcode(byte opcode);

    /// <summary>
    /// Sets register 1.
    /// </summary>
    /// <param name="register">Register 1.</param>
    void SetRegister1(byte register);

    /// <summary>
    /// Sets register 2.
    /// </summary>
    /// <param name="register">Register 2.</param>
    void SetRegister2(byte register);

    /// <summary>
    /// Sets width.
    /// </summary>
    /// <param name="width">Width.</param>
    void SetWidth(byte width);
  }
}