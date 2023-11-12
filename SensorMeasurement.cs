namespace IntruderAlert;
using System.Runtime.InteropServices;

// Original size: 48 (align 8)
public class SensorMeasurement
{
    private static readonly Random generator = new Random();
    public static SensorMeasurement TakeMeasurement(string room, int intruders)
    {
        return new SensorMeasurement
        {
            CO2 = (CO2Concentration + intruders * 10) + (20 * generator.NextDouble() - 10.0),
            O2 = (O2Concentration - intruders * 0.01) + (0.005 * generator.NextDouble() - 0.0025),
            Temperature = (TemperatureSetting + intruders * 0.05) + (0.5 * generator.NextDouble() - 0.25),
            Humidity = (HumiditySetting + intruders * 0.005) + (0.20 * generator.NextDouble() - 0.10),
            Room = room,
            TimeRecorded = DateTime.Now
        };
    }

    private const double CO2Concentration = 409.8; // increases with people.
    private const double O2Concentration = 0.2100; // decreases
    private const double TemperatureSetting = 67.5; // increases
    private const double HumiditySetting = 0.4500; // increases

    public required double CO2 { get; init; } // 8
    public required double O2 { get; init; } // 8
    public required double Temperature { get; init; } // 8
    public required double Humidity { get; init; } // 8
    public required string Room { get; init; } // 8
    public required DateTime TimeRecorded { get; init; } // 8

    public override string ToString() => $"""
            Room: {Room} at {TimeRecorded}:
                Temp:      {Temperature:F3}
                Humidity:  {Humidity:P3}
                Oxygen:    {O2:P3}
                CO2 (ppm): {CO2:F3}
            """;
}
public readonly struct SensorMeasurementStruct
{
    private static readonly Random generator = new Random();
    public static SensorMeasurementStruct TakeMeasurement(string room, int intruders)
    {
        return new SensorMeasurementStruct
        {
            CO2 = (CO2Concentration + intruders * 10) + (20 * generator.NextDouble() - 10.0),
            O2 = (O2Concentration - intruders * 0.01) + (0.005 * generator.NextDouble() - 0.0025),
            Temperature = (TemperatureSetting + intruders * 0.05) + (0.5 * generator.NextDouble() - 0.25),
            Humidity = (HumiditySetting + intruders * 0.005) + (0.20 * generator.NextDouble() - 0.10),
            Room = room,
            TimeRecorded = DateTime.Now
        };
    }

    private const double CO2Concentration = 409.8; // increases with people.
    private const double O2Concentration = 0.2100; // decreases
    private const double TemperatureSetting = 67.5; // increases
    private const double HumiditySetting = 0.4500; // increases

    public required double CO2 { get; init; } // 8
    public required double O2 { get; init; } // 8
    public required double Temperature { get; init; } // 8
    public required double Humidity { get; init; } // 8
    public required string Room { get; init; } // 8
    public required DateTime TimeRecorded { get; init; } // 8

    public override string ToString() => $"""
            Room: {Room} at {TimeRecorded}:
                Temp:      {Temperature:F3}
                Humidity:  {Humidity:P3}
                Oxygen:    {O2:P3}
                CO2 (ppm): {CO2:F3}
            """;
}


// Original size: 48 (align 8)
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly struct SensorMeasurementStructSeq
{
    private static readonly Random generator = new Random();
    public static SensorMeasurementStructSeq TakeMeasurement(string room, int intruders)
    {
        return new SensorMeasurementStructSeq
        {
            CO2 = (CO2Concentration + intruders * 10) + (20 * generator.NextDouble() - 10.0),
            O2 = (O2Concentration - intruders * 0.01) + (0.005 * generator.NextDouble() - 0.0025),
            Temperature = (TemperatureSetting + intruders * 0.05) + (0.5 * generator.NextDouble() - 0.25),
            Humidity = (HumiditySetting + intruders * 0.005) + (0.20 * generator.NextDouble() - 0.10),
            Room = room,
            TimeRecorded = DateTime.Now
        };
    }

    private const double CO2Concentration = 409.8; // increases with people.
    private const double O2Concentration = 0.2100; // decreases
    private const double TemperatureSetting = 67.5; // increases
    private const double HumiditySetting = 0.4500; // increases

    public required double CO2 { get; init; } // 8
    public required double O2 { get; init; } // 8
    public required double Temperature { get; init; } // 8
    public required double Humidity { get; init; } // 8
    public required string Room { get; init; } // 8
    public required DateTime TimeRecorded { get; init; } // 8

    public override string ToString() => $"""
            Room: {Room} at {TimeRecorded}:
                Temp:      {Temperature:F3}
                Humidity:  {Humidity:P3}
                Oxygen:    {O2:P3}
                CO2 (ppm): {CO2:F3}
            """;
}
