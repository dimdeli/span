using System;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Running;

namespace Span_Lab
{
    [CoreJob]
    [MemoryDiagnoser]
    public class StringTest
    {
        [Params(null, "  foo bar", "   The quick brown fox jumps over the lazy dog")]
        public string Inputs;

        [Benchmark]
        public string SafeTrimStart()
        {
            string text = Inputs;

            if (string.IsNullOrWhiteSpace(text)) {
                return text;
            }

            return text.TrimStart();
        }

        [Benchmark]
        public ReadOnlySpan<char> SafeTrimStartSpan()
        {
            ReadOnlySpan<char> text = Inputs.AsSpan();

            if (text.IsEmpty) {
                return text;
            }

            int i = 0;
            char c;

            while ((c = text[i]) == ' ') {
                i++;
            }

            return text.Slice(i);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringTest>();
        }
    }
}
