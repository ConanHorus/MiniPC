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

      BufferMarshal.SetInBuffer(0x01, arr, 1, 1);

      Assert.AreEqual((byte)0x01, arr[1]);
    }

    [TestMethod]
    public void ReadByte()
    {
      var arr = new byte[] { 0, 0x01, 0 };

      byte v = (byte)BufferMarshal.GetFromBuffer(arr, 1, 1);

      Assert.AreEqual(0x01, v);
    }

    [TestMethod]
    public void WriteHalfWord()
    {
      var arr = new byte[4];

      BufferMarshal.SetInBuffer(0x01_02, arr, 1, 2);

      Assert.AreEqual(0x01, arr[1], "Byte 1");
      Assert.AreEqual(0x02, arr[2], "Byte 2");
    }

    [TestMethod]
    public void ReadHalfWord()
    {
      var arr = new byte[] { 0, 0x01, 0x02, 0 };

      ushort v = (ushort)BufferMarshal.GetFromBuffer(arr, 1, 2);

      Assert.AreEqual((ushort)0x01_02, v);
    }

    [TestMethod]
    public void WriteWord()
    {
      var arr = new byte[6];

      BufferMarshal.SetInBuffer(0x01_02_03_04, arr, 1, 4);

      Assert.AreEqual(0x01, arr[1], "Byte 1");
      Assert.AreEqual(0x02, arr[2], "Byte 2");
      Assert.AreEqual(0x03, arr[3], "Byte 3");
      Assert.AreEqual(0x04, arr[4], "Byte 4");
    }

    [TestMethod]
    public void ReadWord()
    {
      var arr = new byte[] { 0, 0x01, 0x02, 0x03, 0x04, 0 };

      uint v = (uint)BufferMarshal.GetFromBuffer(arr, 1, 4);

      Assert.AreEqual((uint)0x01_02_03_04, v);
    }

    [TestMethod]
    public void WriteDoubleWord()
    {
      var arr = new byte[10];

      BufferMarshal.SetInBuffer(0x01_02_03_04_05_06_07_08, arr, 1, 8);

      Assert.AreEqual(0x01, arr[1], "Byte 1");
      Assert.AreEqual(0x02, arr[2], "Byte 2");
      Assert.AreEqual(0x03, arr[3], "Byte 3");
      Assert.AreEqual(0x04, arr[4], "Byte 4");
      Assert.AreEqual(0x05, arr[5], "Byte 5");
      Assert.AreEqual(0x06, arr[6], "Byte 6");
      Assert.AreEqual(0x07, arr[7], "Byte 7");
      Assert.AreEqual(0x08, arr[8], "Byte 8");
    }

    [TestMethod]
    public void ReadDoubleWord()
    {
      var arr = new byte[] { 0, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0 };

      ulong v = BufferMarshal.GetFromBuffer(arr, 1, 8);

      Assert.AreEqual((ulong)0x01_02_03_04_05_06_07_08, v);
    }
  }
}