namespace DataOriented;

using static Constants;

// Original size: 48 (align 8)
public class ClassMeasurement
{
    private static readonly Random generator = new Random();
    public static ClassMeasurement TakeMeasurement(string room, int intruders)
    {
        return new ClassMeasurement
        {
            CO2 = (CO2Concentration + intruders * 10) + (20 * generator.NextDouble() - 10.0),
            O2 = (O2Concentration - intruders * 0.01) + (0.005 * generator.NextDouble() - 0.0025),
            Temperature = (TemperatureSetting + intruders * 0.05) + (0.5 * generator.NextDouble() - 0.25),
            Humidity = (HumiditySetting + intruders * 0.005) + (0.20 * generator.NextDouble() - 0.10),
            Room = room,
            TimeRecorded = DateTime.Now
        };
    }

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