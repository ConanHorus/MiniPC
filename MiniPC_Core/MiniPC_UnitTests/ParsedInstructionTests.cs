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
  public class ParsedInstructionTests
  {
    [TestMethod]
    public void OpCode()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xA8_00_00_00);

      Assert.AreEqual((byte)0x2A, instruction.Opcode);
    }

    [TestMethod]
    public void Width()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFE_00_00_00);

      Assert.AreEqual((byte)0x02, instruction.Width);
    }

    [TestMethod]
    public void Width_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFE_00_00_00);
      _ = instruction.Width;
      instruction.LoadRawInstruction(0xFD_00_00_00);

      Assert.AreEqual((byte)0x01, instruction.Width);
    }

    [TestMethod]
    public void Register1()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_A0_00_00);

      Assert.AreEqual((byte)0x05, instruction.Register1);
    }

    [TestMethod]
    public void Register1_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_A0_00_00);
      _ = instruction.Register1;
      instruction.LoadRawInstruction(0xFF_40_00_00);

      Assert.AreEqual((byte)0x02, instruction.Register1);
    }

    [TestMethod]
    public void Register2()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_F4_00_00);

      Assert.AreEqual((byte)0x05, instruction.Register2);
    }

    [TestMethod]
    public void Register2_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_F4_00_00);
      _ = instruction.Register2;
      instruction.LoadRawInstruction(0xFF_E8_00_00);

      Assert.AreEqual((byte)0x02, instruction.Register2);
    }

    [TestMethod]
    public void Address()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_AA_AA);

      Assert.AreEqual((ushort)0xAA_AA, instruction.Address);
    }

    [TestMethod]
    public void Address_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_AA_AA);
      _ = instruction.Address;
      instruction.LoadRawInstruction(0xFF_FF_55_55);

      Assert.AreEqual((ushort)0x55_55, instruction.Address);
    }

    [TestMethod]
    public void Immediate()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_FF_AA);

      Assert.AreEqual((byte)0xAA, instruction.Immediate);
    }

    [TestMethod]
    public void Immediate_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_FF_AA);
      _ = instruction.Immediate;
      instruction.LoadRawInstruction(0xFF_FF_FF_55);

      Assert.AreEqual((byte)0x55, instruction.Immediate);
    }

    [TestMethod]
    public void Offset()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_00_AA);

      Assert.AreEqual((short)-86, instruction.Offset);
    }

    [TestMethod]
    public void Offset_Dirty()
    {
      var instruction = new ParsedInstruction();

      instruction.LoadRawInstruction(0xFF_FF_00_AA);
      _ = instruction.Offset;
      instruction.LoadRawInstruction(0xFF_FF_00_55);

      Assert.AreEqual((short)85, instruction.Offset);
    }
  }
}