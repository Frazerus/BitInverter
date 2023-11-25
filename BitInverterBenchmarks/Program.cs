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
    public ulong Invert() => _bitInverter.Invert(_value);

    [Benchmark]
    public ulong Invert_v02_No_Branch() => _bitInverter.Invert_v02_No_Branch(_value);
  }

  public class Program
  {
    public static void Main()
    {
      var summary = BenchmarkRunner.Run<BitInverterBenchmark>();
    }
  }
}