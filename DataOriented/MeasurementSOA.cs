namespace DataOriented;

public struct MeasurementSOA
{
    private static readonly Random _generator = new();
    private const double CO2Concentration = 409.8; // increases with people.
    private const double O2Concentration = 0.2100; // decreases
    private const double TemperatureSetting = 67.5; // increases
    private const double HumiditySetting = 0.4500; // increases

    public double[] CO2;
    public double[] O2;
    public double[] Temperature;
    public double[] Humidity;

    public static MeasurementSOA InitCapacity(int capacity)
    {
        return new()
        {
            CO2 = new double[capacity],
            O2 = new double[capacity],
            Temperature = new double[capacity],
            Humidity = new double[capacity]
        };
    }

    public static MeasurementSOA Measure(int count, int intruders)
    {
        var result = InitCapacity(count);
        var i = 0;
        while (i < count)
        {
            result.CO2[i] = (CO2Concentration + intruders * 10) + (20 * _generator.NextDouble() - 10.0);
            result.O2[i] = (O2Concentration - intruders * 0.01) + (0.005 * _generator.NextDouble() - 0.0025);
            result.Temperature[i] = (TemperatureSetting + intruders * 0.05) + (0.5 * _generator.NextDouble() - 0.25);
            result.Humidity[i] = (HumiditySetting + intruders * 0.005) + (0.20 * _generator.NextDouble() - 0.10);
            i++;
        }
        return result;
    }

    public static void MeasureStackAlloc(int count, int intruders)
    {
        Span<double> CO2 = stackalloc double[count];
        Span<double> O2 = stackalloc double[count];
        Span<double> Temperature = stackalloc double[count];
        Span<double> Humidity = stackalloc double[count];

        var i = 0;
        while (i < count)
        {
            CO2[i] = (CO2Concentration + intruders * 10) + (20 * _generator.NextDouble() - 10.0);
            O2[i] = (O2Concentration - intruders * 0.01) + (0.005 * _generator.NextDouble() - 0.0025);
            Temperature[i] = (TemperatureSetting + intruders * 0.05) + (0.5 * _generator.NextDouble() - 0.25);
            Humidity[i] = (HumiditySetting + intruders * 0.005) + (0.20 * _generator.NextDouble() - 0.10);
            i++;
        }
    }

    public static void DoSomething(ref MeasurementSOA soa)
    {
        var i = 0;
        while (i < soa.CO2.Length)
        {
            soa.CO2[i] = soa.CO2[i] * 2;
            i++;
        }
    }
}