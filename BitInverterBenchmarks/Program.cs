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


    [Benchmark]
    public ulong Invert() => _bitInverter.Invert(12u);

    [Benchmark]
    public ulong Invert_v02_No_Branch() => _bitInverter.Invert_v02_No_Branch(12u);
  }

  public class Program
  {
    public static void Main()
    {
      var summary = BenchmarkRunner.Run<BitInverterBenchmark>();
    }
  }
}