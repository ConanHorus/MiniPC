using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniPC_Library.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPC_UnitTests
{
  [TestClass]
  public class ALUTests
  {
    [TestMethod]
    public void LeftShift()
    {
      var alu = new ALU();

      alu.StageValue(0, 1);
      alu.PerformAction(ALUCalculation.ShiftLeft, 1);

      Assert.AreEqual(2, alu.ReadResult());
    }

    [TestMethod]
    public void RightShift()
    {
      var alu = new ALU();

      unchecked
      {
        alu.StageValue(0, (long)0x80_00_00_00_00_00_00_00);
        alu.PerformAction(ALUCalculation.ShiftRight, 1);

        Assert.AreEqual((long)0xC0_00_00_00_00_00_00_00, alu.ReadResult());
      }
    }

    [TestMethod]
    public void RightShiftZeroFill()
    {
      var alu = new ALU();

      unchecked
      {
        alu.StageValue(0, (long)0x80_00_00_00_00_00_00_00);
        alu.PerformAction(ALUCalculation.ShiftRightZeroFill, 1);
      }

      Assert.AreEqual(0x40_00_00_00_00_00_00_00, alu.ReadResult());
    }

    [TestMethod]
    public void Add()
    {
      var alu = new ALU();

      alu.StageValue(0, 1);
      alu.StageValue(1, 1);
      alu.PerformAction(ALUCalculation.Add);

      Assert.AreEqual(2, alu.ReadResult());
    }

    [TestMethod]
    public void Subtract()
    {
      var alu = new ALU();

      alu.StageValue(0, 2);
      alu.StageValue(1, 1);
      alu.PerformAction(ALUCalculation.Subtract);

      Assert.AreEqual(1, alu.ReadResult());
    }

    [TestMethod]
    public void Multiply()
    {
      var alu = new ALU();

      alu.StageValue(0, 2);
      alu.StageValue(1, 3);
      alu.PerformAction(ALUCalculation.Multiply);

      Assert.AreEqual(6, alu.ReadResult());
    }

    [TestMethod]
    public void Divide()
    {
      var alu = new ALU();

      alu.StageValue(0, 4);
      alu.StageValue(1, 2);
      alu.PerformAction(ALUCalculation.Divide);

      Assert.AreEqual(2, alu.ReadResult());
    }

    [TestMethod]
    public void Not()
    {
      var alu = new ALU();

      alu.StageValue(0, -1);
      alu.PerformAction(ALUCalculation.Not);

      Assert.AreEqual(0, alu.ReadResult());
    }

    [TestMethod]
    public void And()
    {
      var alu = new ALU();

      alu.StageValue(0, 3);
      alu.StageValue(1, 1);
      alu.PerformAction(ALUCalculation.And);

      Assert.AreEqual(1, alu.ReadResult());
    }

    [TestMethod]
    public void Xor()
    {
      var alu = new ALU();

      alu.StageValue(0, 3);
      alu.StageValue(1, 1);
      alu.PerformAction(ALUCalculation.Xor);

      Assert.AreEqual(2, alu.ReadResult());
    }
  }
}