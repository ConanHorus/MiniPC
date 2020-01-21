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
    /// <inheritdoc/>
    public void PerformCycle(ProcessorState processorState, EmulatedMemory memory)
    {
      const int OPCODE_SHIFT = 26;
      const byte OPCODE_MASK = 0b0011_1111;

      uint rawInstruction = memory.GetWord(processorState.ProgramCounter);
      processorState.ProgramCounter += EmulatedMemory.WORD_LENGTH;

      byte opcode = (byte)((rawInstruction >> OPCODE_SHIFT) & OPCODE_MASK);

      // todo decide program flow based on opcode
      throw new NotImplementedException();
    }
  }
}