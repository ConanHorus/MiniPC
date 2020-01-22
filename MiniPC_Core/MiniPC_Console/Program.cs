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
  /// Startup class.
  /// </summary>
  internal class Program
  {
    /// <summary>
    /// Container.
    /// </summary>
    private static readonly Container Container = new Container();

    /// <summary>
    /// Entroy point of program.
    /// </summary>
    /// <param name="args">Args.</param>
    private static void Main(string[] args)
    {
      SetupContainerGraph();
    }

    /// <summary>
    /// Registers container graph.
    /// </summary>
    private static void SetupContainerGraph()
    {
      Container.Register<IParsedInstruction, ParsedInstruction>();
      Container.Register<IEmulatedMemory, EmulatedMemory>(Lifestyle.Singleton);
      Container.Register<IALU, ALU>();
      Container.Register<IProcessorState, ProcessorState>();
      Container.Register<IProcessor, Processor>();

      Container.Verify();
    }
  }
}