// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using TurboCollections;

TurboCollections.TurboMaths.SayHello();

var sw = new Stopwatch();
sw.Start();
Console.WriteLine(TurboMaths.FibonacciRecursive(40));
sw.Stop();
Console.WriteLine($"Time elapsed (recursive): {sw.Elapsed}");
sw.Reset();
sw.Start();
Console.WriteLine(TurboMaths.FibonacciIterative(40));
sw.Stop();
Console.WriteLine($"Time elapsed (iterative): {sw.Elapsed}");