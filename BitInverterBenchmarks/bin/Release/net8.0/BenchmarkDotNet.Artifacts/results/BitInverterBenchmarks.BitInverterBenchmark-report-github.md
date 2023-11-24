```

BenchmarkDotNet v0.13.10, Windows 10 (10.0.19045.3693/22H2/2022Update)
11th Gen Intel Core i9-11900K 3.50GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 8.0.100
  [Host]    : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  RyuJitX64 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

Job=RyuJitX64  Jit=RyuJit  Platform=X64  

```
| Method | Mean     | Error    | StdDev   | Code Size |
|------- |---------:|---------:|---------:|----------:|
| Invert | 28.85 ns | 0.599 ns | 1.140 ns |      54 B |
