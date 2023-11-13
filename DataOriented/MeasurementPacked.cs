using System.Runtime.InteropServices;

namespace DataOriented;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public readonly struct MeasurementPacked
{
	private static readonly Random generator = new Random();
	public static MeasurementPacked TakeMeasurement(int intruders)
	{
		return new MeasurementPacked
		{
			CO2 = (Constants.CO2Concentration + intruders * 10) + (20 * generator.NextDouble() - 10.0),
			O2 = (Constants.O2Concentration - intruders * 0.01) + (0.005 * generator.NextDouble() - 0.0025),
			Temperature = (Constants.TemperatureSetting + intruders * 0.05) + (0.5 * generator.NextDouble() - 0.25),
			Humidity = (Constants.HumiditySetting + intruders * 0.005) + (0.20 * generator.NextDouble() - 0.10),
			TimeRecorded = DateTime.Now
		};
	}

	public required double CO2 { get; init; } // 8
	public required double O2 { get; init; } // 8
	public required double Temperature { get; init; } // 8
	public required double Humidity { get; init; } // 8
	public required DateTime TimeRecorded { get; init; } // 8
}
