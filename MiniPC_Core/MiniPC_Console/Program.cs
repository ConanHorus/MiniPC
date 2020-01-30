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
    /// Entroy point of program.
    /// </summary>
    /// <param name="args">Args.</param>
    private static void Main(string[] args)
    {
      var pc = new PC();
    }
  }
}