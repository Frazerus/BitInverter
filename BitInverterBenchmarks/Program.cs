using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using BitInverter;

namespace BitInverterBenchmarks
{
  [DisassemblyDiagnoser(syntax: DisassemblySyntax.Masm, printSource: true)]
  [RyuJitX64Job]
  public class BitInverterBenchmark
  {
    private BitInverterBase _bitInverter = new BitInverterBase();

    private ulong _value = ((ulong)RandomNumberGenerator.GetInt32(Int32.MinValue, Int32.MaxValue) << 32)
                           + (ulong)RandomNumberGenerator.GetInt32(Int32.MinValue, Int32.MaxValue);

    [Benchmark]
    public ulong Invert () => _bitInverter.Invert(_value);

    [Benchmark]
    public ulong Invert_v02_No_Branch () => _bitInverter.Invert_v02_No_Branch(_value);

    [Benchmark]
    public ulong Invert_v03_Log2 () => _bitInverter.Invert_v03_Log2(_value);

    [Benchmark]
    public ulong Invert_v03a_Log2_XOR () => _bitInverter.Invert_v03a_Log2_XOR(_value);

    [Benchmark]
    public ulong Invert_v03b_Log2_Compact () => _bitInverter.Invert_v03b_Log2_Compact(_value);

    [Benchmark]
    public ulong Invert_v04_Log2_ReverseEndianness () => _bitInverter.Invert_v04_Log2_ReverseEndianness(_value);

    [Benchmark]
    public ulong Invert_v05 () => _bitInverter.Invert_v05(_value);
    
    [Benchmark]
    public ulong Invert_v05a_Log2_SimdShuffleWithCachedIndices () => _bitInverter.Invert_v05a_Log2_SimdShuffleWithCachedIndices(_value);
  }

  public class Program
  {
    public static void Main ()
    {
      var summary = BenchmarkRunner.Run<BitInverterBenchmark>();
    }
  }
}