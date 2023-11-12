using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using IntruderAlert;
using System.Runtime.InteropServices;
using System.Text;

var r = new Random();

int counter = 0;
var size = Marshal.SizeOf(typeof(SensorMeasurementStruct));
var dsize = Marshal.SizeOf(typeof(double));

Console.WriteLine($"Size of sensor measurement: {size}");
Console.WriteLine($"Total measurement size: {size * Benchmarks.samplesize / 1024}");

BenchmarkRunner.Run<Benchmarks>();

[HardwareCounters(HardwareCounter.Timer, HardwareCounter.CacheMisses, HardwareCounter.TotalCycles)]
public class Benchmarks
{
    public const int samplesize = 20000;
    
    [Benchmark]
    public void ClassMeasurementList()
    {
        var list = new List<SensorMeasurement>();
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(SensorMeasurement.TakeMeasurement("test", 100));
        }
    }

    [Benchmark]
    public void ClassMeasurementListPrealloc()
    {
        var list = new List<SensorMeasurement>(samplesize);
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(SensorMeasurement.TakeMeasurement("test", 100));
        }
    }

    [Benchmark]
    public void ClassMeasurementStructList()
    {
        var list = new List<SensorMeasurementStruct>();
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(SensorMeasurementStruct.TakeMeasurement("test", 100));
        }
    }

    [Benchmark]
    public void ClassMeasurementStructListPrealloc()
    {
        var list = new List<SensorMeasurementStruct>(samplesize);
        for (int i = 0; i < samplesize; i++)
        {
            list.Add(SensorMeasurementStruct.TakeMeasurement("test", 100));
        }
    }

    [Benchmark]
    public void ClassMeasurementStructArray()
    {
        var list = new SensorMeasurementStruct[samplesize];
        for (int i = 0; i < samplesize; i++)
        {
            list[i] = SensorMeasurementStruct.TakeMeasurement("test", 100);
        }
    }

    [Benchmark]
    public void ClassMeasurementStructSeqArray()
    {
        var list = new SensorMeasurementStructSeq[samplesize];
        for (int i = 0; i < samplesize; i++)
        {
            list[i] = SensorMeasurementStructSeq.TakeMeasurement("test", 100);
        }
    }
}



//room.TakeMeasurements(
//    m =>
//    {
//        Console.WriteLine(room.Debounce);
//        Console.WriteLine(room.Average);
//        Console.WriteLine();
//        counter++;
//        return counter < 20000;
//    });

//counter = 0;
//room.TakeMeasurements(
//    m =>
//    {
//        Console.WriteLine(room.Debounce);
//        Console.WriteLine(room.Average);
//        room.Intruders += (room.Intruders, r.Next(5)) switch
//        {
//            ( > 0, 0) => -1,
//            ( < 3, 1) => 1,
//            _ => 0
//        };

//        Console.WriteLine($"Current intruders: {room.Intruders}");
//        Console.WriteLine($"Calculated intruder risk: {room.RiskStatus}");
//        Console.WriteLine();
//        counter++;
//        return counter < 200000;
//    });