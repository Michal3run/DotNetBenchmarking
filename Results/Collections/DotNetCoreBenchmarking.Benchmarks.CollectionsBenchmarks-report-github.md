``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i5-7200U CPU 2.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=3.1.401
  [Host]     : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.7 (CoreCLR 4.700.20.36602, CoreFX 4.700.20.37001), X64 RyuJIT


```
|               Method |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|        ListBenchmark | 330.58 μs | 20.256 μs | 56.129 μs | 352.20 μs |  1.00 |    0.00 |  2.4414 |     - |     - |   4.13 KB |
|       ArrayBenchmark | 377.82 μs | 14.049 μs | 39.856 μs | 390.60 μs |  1.20 |    0.37 |  2.4414 |     - |     - |   4.09 KB |
| ArraySimpleBenchmark | 337.66 μs |  9.743 μs | 28.110 μs | 347.20 μs |  1.06 |    0.30 |  2.4414 |     - |     - |   4.01 KB |
|     HashsetBenchmark |  92.79 μs |  6.449 μs | 19.016 μs |  98.56 μs |  0.30 |    0.13 | 36.9873 |     - |     - |  57.45 KB |
|  DictionaryBenchmark |  95.91 μs |  2.582 μs |  7.408 μs |  98.08 μs |  0.30 |    0.09 | 46.5088 |     - |     - |  71.61 KB |
|      LookupBenchmark | 173.84 μs |  5.302 μs | 15.383 μs | 177.03 μs |  0.55 |    0.16 | 66.4063 |     - |     - | 102.21 KB |
