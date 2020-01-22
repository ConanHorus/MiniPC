using System;
using System.Collections.Generic;
using System.Text;
using MiniPC_Library.Memory;

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
      uint rawInstruction = this.memory.GetWord(this.state.ProgramCounter);
      this.parsedInstruction.LoadRawInstruction(rawInstruction);
      this.state.ProgramCounter += EmulatedMemory.WORD_LENGTH;

      // todo decide program flow based on opcode
      throw new NotImplementedException();
    }
  }
}