using MiniPC_Library.Memory;

namespace MiniPC_Library.Processing.ProcessorActions
{
  /// <summary>
  /// Data location.
  /// </summary>
  public interface IDataLocationStrategy
  {
    /// <summary>
    /// Puts data.
    /// </summary>
    /// <param name="instruction">Instruction.</param>
    /// <param name="memory">Memory.</param>
    /// <param name="state">Processor state.</param>
    /// <param name="alu">ALU.</param>
    /// <param name="value">value.</param>
    void PutData(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu, long value);

    /// <summary>
    /// Gets data.
    /// </summary>
    /// <param name="instruction">Instruction.</param>
    /// <param name="memory">Memory.</param>
    /// <param name="state">Processor state.</param>
    /// <param name="alu">ALU.</param>
    /// <returns>Value.</returns>
    long GetData(IParsedInstruction instruction, IEmulatedMemory memory, IProcessorState state, IALU alu);
  }
}