using MiniPC_Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPC_IntegratedTests
{
  internal class Program
  {
    private static PC pc = new PC();

    private static void Main(string[] args)
    {
      pc.WriteToMemory(GetShortProgram(), 0);
      pc.RunUntilHalted();

      Console.WriteLine(pc.GetRegister(0) == 0x55_55_55_55);
      Console.ReadLine();
    }

    private static IEnumerable<uint> GetShortProgram()
    {
      // todo make more programs - make generic testing platform
      yield return 0x80_00_00_28; //  0 : Load R0 from 40
      yield return 0x80_20_00_29; //  4 : Load R1 from 41
      yield return 0x18_04_00_00; //  8 : Multiply R0 and R1 into R0
      yield return 0x80_20_00_2A; // 12 : Load R1 from 42
      yield return 0x40_04_00_00; // 16 : Compare R0 with R1
      yield return 0x48_00_00_20; // 20 : Jump if equal to 32
      yield return 0x82_00_00_2C; // 24 : Load R0 from 44
      yield return 0x00_00_00_00; // 28 : HALT
      yield return 0x82_00_00_30; // 32 : Load R0 from 48
      yield return 0x00_00_00_00; // 36 : HALT
      yield return 0x02_03_06_00; // 40 : 2, 3, 6
      yield return 0xAA_AA_AA_AA; // 44 : AAAAAAAA
      yield return 0x55_55_55_55; // 48 : 55555555
    }
  }
}