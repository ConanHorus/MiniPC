using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniPC_Library.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPC_UnitTests
{
  [TestClass]
  public class BufferMarshalTests
  {
    [TestMethod]
    public void WriteByte()
    {
      var arr = new byte[3];

      BufferMarshal.SetInBuffer(0xAA, arr, 1, 1);

      Assert.AreEqual((byte)0xAA, arr[1]);
    }

    [TestMethod]
    public void ReadByte()
    {
      var arr = new byte[] { 0, 0xAA, 0 };

      byte v = (byte)BufferMarshal.GetFromBuffer(arr, 1, 1);

      Assert.AreEqual(0xAA, v);
    }

    [TestMethod]
    public void WriteHalfWord()
    {
      var arr = new byte[4];

      BufferMarshal.SetInBuffer(0xAA_AA, arr, 1, 2);

      Assert.AreEqual(0xAA, arr[1], "Byte 1");
      Assert.AreEqual(0xAA, arr[2], "Byte 2");
    }

    [TestMethod]
    public void ReadHalfWord()
    {
      var arr = new byte[] { 0, 0xAA, 0xAA, 0 };

      ushort v = (ushort)BufferMarshal.GetFromBuffer(arr, 1, 2);

      Assert.AreEqual((ushort)0xAA_AA, v);
    }

    [TestMethod]
    public void WriteWord()
    {
      var arr = new byte[6];

      BufferMarshal.SetInBuffer(0xAA_AA_AA_AA, arr, 1, 4);

      Assert.AreEqual(0xAA, arr[1], "Byte 1");
      Assert.AreEqual(0xAA, arr[2], "Byte 2");
      Assert.AreEqual(0xAA, arr[3], "Byte 3");
      Assert.AreEqual(0xAA, arr[4], "Byte 4");
    }

    [TestMethod]
    public void ReadWord()
    {
      var arr = new byte[] { 0, 0xAA, 0xAA, 0xAA, 0xAA, 0 };

      uint v = (uint)BufferMarshal.GetFromBuffer(arr, 1, 4);

      Assert.AreEqual(0xAA_AA_AA_AA, v);
    }

    [TestMethod]
    public void WriteDoubleWord()
    {
      var arr = new byte[10];

      BufferMarshal.SetInBuffer(0xAA_AA_AA_AA_AA_AA_AA_AA, arr, 1, 8);

      Assert.AreEqual(0xAA, arr[1], "Byte 1");
      Assert.AreEqual(0xAA, arr[2], "Byte 2");
      Assert.AreEqual(0xAA, arr[3], "Byte 3");
      Assert.AreEqual(0xAA, arr[4], "Byte 4");
      Assert.AreEqual(0xAA, arr[5], "Byte 5");
      Assert.AreEqual(0xAA, arr[6], "Byte 6");
      Assert.AreEqual(0xAA, arr[7], "Byte 7");
      Assert.AreEqual(0xAA, arr[8], "Byte 8");
    }

    [TestMethod]
    public void ReadDoubleWord()
    {
      var arr = new byte[] { 0, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0xAA, 0 };

      ulong v = BufferMarshal.GetFromBuffer(arr, 1, 8);

      Assert.AreEqual(0xAA_AA_AA_AA_AA_AA_AA_AA, v);
    }
  }
}