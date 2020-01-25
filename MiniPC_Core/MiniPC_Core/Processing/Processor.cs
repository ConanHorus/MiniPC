using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;
using MiniPC_Library.Processing.ProcessorInstructions;

namespace MiniPC_Library.Processing
{
  /// <inheritdoc/>
  public class Processor
    : IProcessor
  {
    /// <summary>
    /// Parsed isntruction.
    /// </summary>
    private readonly IParsedInstruction parsedInstruction;

    /// <summary>
    /// Memory.
    /// </summary>
    private readonly IEmulatedMemory memory;

    /// <summary>
    /// ALU.
    /// </summary>
    private readonly IALU alu;

    /// <summary>
    /// Processor state.
    /// </summary>
    private readonly IProcessorState state;

    /// <summary>
    /// Processor instructions lookup table.
    /// </summary>
    private readonly ProcessorInstructionBase[] instructionLookup = new ProcessorInstructionBase[]
    {
      // 000000
      null,
      new LeftShift(),
      new RightShiftKeepSign(),
      new RightShiftZeroFill(),

      // 000100
      new Add(),
      new Subtract(),
      new Multiply(),
      new Divide(),

      // 001000
      new Not(),
      new And(),
      new Xor(),
      null,

      // 001100
      new GetProgramCounter(),
      new SetProgramCounter(),
      null,
      null,

      // 010000
      new CompareRegisters(),
      new Jump(true, false, false),
      new Jump(false, true, false),
      new Jump(true, true, false),

      // 010100
      new Jump(false, false, true),
      new Jump(true, false, true),
      new Jump(false, true, true),
      new Jump(true, true, true),

      // 011000
      new CompareMemory(),
      new Branch(true, false, false),
      new Branch(false, true, false),
      new Branch(true, true, false),

      // 011100
      new Branch(false, false, true),
      new Branch(true, false, true),
      new Branch(false, true, true),
      new Branch(true, true, true),

      // 100000
      null,
      null,
      null,
      null,

      // 100100
      null,
      null,
      null,
      null,

      // 101000
      null,
      null,
      null,
      null,

      // 101100
      null,
      null,
      null,
      null,

      // 110000
      null,
      null,
      null,
      null,

      // 110100
      null,
      null,
      null,
      null,

      // 111000
      null,
      null,
      null,
      null,

      // 111100
      null,
      null,
      null,
      null,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="Processor"/> class.
    /// </summary>
    /// <param name="parsedInstruction">Parsed instruction.</param>
    /// <param name="memory">Memory.</param>
    /// <param name="alu">ALU.</param>
    /// <param name="state">Processor state.</param>
    public Processor(IParsedInstruction parsedInstruction, IEmulatedMemory memory, IALU alu, IProcessorState state)
    {
      this.parsedInstruction = parsedInstruction;
      this.memory = memory;
      this.alu = alu;
      this.state = state;
    }

    /// <inheritdoc/>
    public void PerformCycle()
    {
      const byte INSTRUCTION_WIDTH = 2; // word (4 bytes)

      uint rawInstruction = (uint)this.memory.GetValue(INSTRUCTION_WIDTH, this.state.ProgramCounter);
      this.parsedInstruction.LoadRawInstruction(rawInstruction);
      this.state.ProgramCounter += EmulatedMemory.WORD_LENGTH;

      var instruction = this.instructionLookup[this.parsedInstruction.Opcode];
      if (instruction is null)
      {
        this.state.Halted = true;
      }
      else
      {
        instruction.PerformActions(this.parsedInstruction, this.memory, this.state, this.alu);
      }
    }
  }
}