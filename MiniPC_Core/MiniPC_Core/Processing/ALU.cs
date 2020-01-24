using System;
using System.Collections.Generic;
using System.Text;

namespace MiniPC_Library.Processing
{
  /// <inheritdoc/>
  public class ALU
    : IALU
  {
    /// <summary>
    /// Number of registers.
    /// </summary>
    public const int REGISTER_COUNT = 2;

    /// <summary>
    /// ALU registers.
    /// </summary>
    private readonly long[] registers = new long[REGISTER_COUNT];

    /// <inheritdoc/>
    public void StageValue(int register, long value)
    {
      this.registers[register] = value;
    }

    /// <inheritdoc/>
    public long ReadResult()
    {
      return this.registers[0];
    }

    /// <inheritdoc/>
    public void PerformAction(ALUCalculation calculation) // todo unit test
    {
      this.PerformAction(calculation, 0);
    }

    /// <inheritdoc/>
    public void PerformAction(ALUCalculation calculation, int value) // todo unit test
    {
      switch (calculation)
      {
        case ALUCalculation.Add:
          this.Add();
          break;

        case ALUCalculation.And:
          this.And();
          break;

        case ALUCalculation.Divide:
          this.Divide();
          break;

        case ALUCalculation.Multiply:
          this.Multiply();
          break;

        case ALUCalculation.Not:
          this.Not();
          break;

        case ALUCalculation.ShiftLeft:
          this.ShiftLeft(value);
          break;

        case ALUCalculation.ShiftRight:
          this.ShiftRight(value);
          break;

        case ALUCalculation.ShiftRightZeroFill:
          this.ShiftRightZeroFill(value);
          break;

        case ALUCalculation.Subtract:
          this.Subtract();
          break;

        case ALUCalculation.Xor:
          this.Xor();
          break;
      }
    }

    /// <summary>
    /// Shifts left.
    /// </summary>
    /// <param name="amount">Shift amount.</param>
    private void ShiftLeft(int amount) // todo unit test
    {
      this.registers[0] <<= amount;
    }

    /// <summary>
    /// Shifts right.
    /// </summary>
    /// <param name="amount">Shift amount.</param>
    private void ShiftRight(int amount) // todo unit test
    {
      this.registers[0] >>= amount;
    }

    /// <summary>
    /// Shifts right with zero fill.
    /// </summary>
    /// <param name="amount">Shift amount.</param>
    private void ShiftRightZeroFill(int amount) // todo unit test
    {
      ulong unsigned = (ulong)this.registers[0];
      unsigned >>= amount;
      this.registers[0] = (long)unsigned;
    }

    /// <summary>
    /// Adds.
    /// </summary>
    private void Add() // todo unit test
    {
      this.registers[0] += this.registers[1];
    }

    /// <summary>
    /// Subtracts.
    /// </summary>
    private void Subtract() // todo unit test
    {
      this.registers[0] -= this.registers[1];
    }

    /// <summary>
    /// Multiplies.
    /// </summary>
    private void Multiply() // todo unit test
    {
      this.registers[0] *= this.registers[1];
    }

    /// <summary>
    /// Divides.
    /// </summary>
    private void Divide() // todo unit test
    {
      this.registers[0] /= this.registers[1];
    }

    /// <summary>
    /// Not.
    /// </summary>
    private void Not() // todo unit test
    {
      const long FF = -1;

      this.registers[0] = this.registers[0] ^ FF;
    }

    /// <summary>
    /// And.
    /// </summary>
    private void And() // todo unit test
    {
      this.registers[0] &= this.registers[1];
    }

    /// <summary>
    /// Xor.
    /// </summary>
    private void Xor() // todo unit test
    {
      this.registers[0] ^= this.registers[1];
    }
  }
}