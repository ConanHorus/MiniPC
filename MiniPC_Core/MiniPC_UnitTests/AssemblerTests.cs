using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniPC_Library.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPC_UnitTests
{
  [TestClass]
  public class AssemblerTests
  {
    [TestMethod]
    public void BreakCodeIntoLines()
    {
      var assembler = new Assembler();
      var code = "Line 1\nLine 2\rLine 3\n\rLine 4\r\nLine 5\n";

      var lines = assembler.SeperateIntoLines(code).ToArray();

      Assert.AreEqual(5, lines.Length, "Line count");
      Assert.AreEqual("Line 5", lines[4], "Line 5");
    }
  }
}