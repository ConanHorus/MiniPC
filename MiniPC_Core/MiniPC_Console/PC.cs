using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniPC_Library.Memory;
using MiniPC_Library.Processing;
using SimpleInjector;

namespace MiniPC_Console
{
  /// <summary>
  /// PC.
  /// </summary>
  public class PC
  {
    /// <summary>
    /// Processor for this PC.
    /// </summary>
    private readonly IProcessor processor;

    /// <summary>
    /// Memory for this PC.
    /// </summary>
    private readonly IEmulatedMemory memory;

    /// <summary>
    /// Processor state for this PC.
    /// </summary>
    private readonly IProcessorState state;

    /// <summary>
    /// Container.
    /// </summary>
    private readonly Container container = new Container();

    /// <summary>
    /// Initializes a new instance of the <see cref="PC"/> class.
    /// </summary>
    public PC()
    {
      this.SetupContainerGraph();
      this.processor = this.container.GetInstance<IProcessor>();
      this.memory = this.container.GetInstance<IEmulatedMemory>();
      this.state = this.container.GetInstance<IProcessorState>();
    }

    /// <summary>
    /// Performs next instruction.
    /// </summary>
    public void RunUntilHalted()
    {
      while (!this.state.Halted)
      {
        this.processor.PerformCycle();
      }
    }

    /// <summary>
    /// Gets register value.
    /// </summary>
    /// <param name="register">Register number.</param>
    /// <returns>Value of register.</returns>
    public long GetRegister(int register)
    {
      return this.state.Registers[register];
    }

    /// <summary>
    /// Writes many values to memory starting and address.
    /// </summary>
    /// <param name="values">Values to write to memory.</param>
    /// <param name="startingAddress">Starting address.</param>
    public void WriteToMemory(IEnumerable<uint> values, ushort startingAddress)
    {
      const int ADDRESS_INCREMENT = 4;

      ushort address = startingAddress;

      foreach (var value in values)
      {
        this.WriteToMemory(value, address);
        address += ADDRESS_INCREMENT;
      }
    }

    /// <summary>
    /// Writes value to memory.
    /// </summary>
    /// <param name="value">Value to write to memory.</param>
    /// <param name="address">Address to write value.</param>
    private void WriteToMemory(uint value, ushort address)
    {
      const int WORD_WIDTH = 2;

      this.memory.SetValue(WORD_WIDTH, value, address);
    }

    /// <summary>
    /// Registers container graph.
    /// </summary>
    private void SetupContainerGraph()
    {
      this.container.Register<IParsedInstruction, ParsedInstruction>(Lifestyle.Singleton);
      this.container.Register<IEmulatedMemory, EmulatedMemory>(Lifestyle.Singleton);
      this.container.Register<IALU, ALU>(Lifestyle.Singleton);
      this.container.Register<IProcessorState, ProcessorState>(Lifestyle.Singleton);
      this.container.Register<IProcessor, Processor>(Lifestyle.Singleton);

      this.container.Verify();
    }
  }
}