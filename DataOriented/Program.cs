using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using DataOriented;
using System.Runtime.InteropServices;
using System.Text;
using BenchmarkDotNet.Order;

var r = new Random();

int counter = 0;
var size = Marshal.SizeOf(typeof(Measurement));
var dsize = Marshal.SizeOf(typeof(double));

Console.WriteLine($"Size of sensor measurement: {size}");
Console.WriteLine($"Total measurement size: {size * Benchmarks.samplesize / 1024}");

BenchmarkRunner.Run<Benchmarks>();

[HardwareCounters(HardwareCounter.Timer, HardwareCounter.CacheMisses, HardwareCounter.TotalCycles)]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class Benchmarks
{
    public const int samplesize = 20000;
    
    //[Benchmark]
    public void ClassMeasurementList()
    {
        var list = new List<ClassMeasurement>();
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(ClassMeasurement.TakeMeasurement("test", 100));
        }
    }

    //[Benchmark]
    public void ClassMeasurementListPrealloc()
    {
        var list = new List<ClassMeasurement>(samplesize);
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(ClassMeasurement.TakeMeasurement("test", 100));
        }
    }

    [Benchmark]
    public void MeasurementStructList()
    {
        var list = new List<Measurement>();
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(Measurement.TakeMeasurement(100));
        }
    }

    [Benchmark]
    public void MeasurementStructListPrealloc()
    {
        var list = new List<Measurement>(samplesize);
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(Measurement.TakeMeasurement(100));
        }
    }

    [Benchmark]
    public void MeasurementStructArray()
    {
        var list = new Measurement[samplesize];
        for (int i = 0; i < samplesize; i++)
        {
            list[i] = Measurement.TakeMeasurement(100);
        }
    }

    [Benchmark]
    public void MeasurementStructSeqArray()
    {
        var list = new MeasurementPacked[samplesize];
        for (int i = 0; i < samplesize; i++)
        {
            list[i] = MeasurementPacked.TakeMeasurement(100);
        }
    }
    
    [Benchmark]
    public void StructMeasurementSoa()
    {
        MeasurementSOA.Measure(samplesize, 100);
    }

    [Benchmark]
    public void StructMeasurementSoaStackAlloc()
    {
        MeasurementSOA.MeasureStackAlloc(samplesize, 100);
    }

    [Benchmark]
    public void MeasurementMultiList()
    {
        DataOriented.MeasurementMultiList.Measure(samplesize, 100);
    }
    
}