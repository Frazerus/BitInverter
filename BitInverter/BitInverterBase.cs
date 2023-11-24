using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace BitInverter;

public class BitInverterBase
{
  [MethodImpl(MethodImplOptions.NoInlining)]
  public ulong Invert (ulong input)
  {
    ulong output = 0;
    for (int i = 0; i < 64; i++)
    {
      ulong currentBitMask = 1ul << i;
      bool currentBit = (currentBitMask & input)!= 0;
      output = output << 1;
      if (currentBit)
      {
        output = output | 0x_00_00_00_00_0_00_00_01;
      }
    }

    //1: 1011  -> bitmask 0001 o = 0000 | 0001
    //2: 1011  -> bitmask 0010 o = 0010 | 0001
    //2: 1011  -> bitmask 0100 o = 0110
    //2: 1011  -> bitmask 1000 o = 1100 | 0001


    return output;
  }
}