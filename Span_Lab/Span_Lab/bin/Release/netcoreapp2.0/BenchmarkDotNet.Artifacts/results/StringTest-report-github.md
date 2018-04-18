``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.15063.966 (1703/CreatorsUpdate/Redstone2)
Intel Core i7-7820HQ CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
Frequency=2835940 Hz, Resolution=352.6168 ns, Timer=TSC
.NET Core SDK=2.1.104
  [Host] : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT  [AttachedDebugger]
  Core   : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|            Method |                                         Inputs |      Mean |     Error |    StdDev |    Median |  Gen 0 | Allocated |
|------------------ |----------------------------------------------- |----------:|----------:|----------:|----------:|-------:|----------:|
|     **SafeTrimStart** |                                              **?** |  **1.750 ns** | **0.0533 ns** | **0.0445 ns** |  **1.748 ns** |      **-** |       **0 B** |
| SafeTrimStartSpan |                                              ? |  3.179 ns | 0.1153 ns | 0.2302 ns |  3.068 ns |      - |       0 B |
|     **SafeTrimStart** | **   The quick brown fox jumps over the lazy dog** | **58.023 ns** | **0.9866 ns** | **0.9229 ns** | **58.025 ns** | **0.0266** |     **112 B** |
| SafeTrimStartSpan |    The quick brown fox jumps over the lazy dog | 10.712 ns | 0.0879 ns | 0.0734 ns | 10.681 ns |      - |       0 B |
|     **SafeTrimStart** |                                      **  foo bar** | **41.594 ns** | **0.4539 ns** | **0.4246 ns** | **41.462 ns** | **0.0095** |      **40 B** |
| SafeTrimStartSpan |                                        foo bar | 10.212 ns | 0.1259 ns | 0.1116 ns | 10.237 ns |      - |       0 B |
