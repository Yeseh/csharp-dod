
namespace DataOriented;

using static Constants;

public struct MeasurementMultiList
{
	public ref struct MeasurementRef
	{
		public ref double Co2;
		public ref double O2;
		public ref double Temperature;
		public ref double Humidity;
	}
	
	private uint _capacity = 0;
	private Memory<double> _co2;
	private Memory<double> _o2;
	private Memory<double> _temperature;
	private Memory<double> _humidity;

	public Span<double> Co2 => _co2.Span;
	public Span<double> O2 => _o2.Span;
	public Span<double> Temperature => _temperature.Span;
	public Span<double> Humidity => _humidity.Span;

	public MeasurementMultiList(ReadOnlySpan<Measurement> ms)
	{
		var capacity = ms.Length;
		_capacity = (uint)capacity;
		_co2 = new Memory<double>(new double[capacity]);
		_o2 = new Memory<double>(new double[capacity]);
		_temperature = new Memory<double>(new double[capacity]);
		_humidity = new Memory<double>(new double[capacity]);
		
		for (var i = 0; i < ms.Length; i++)
		{
			var item = ms[i];
			_co2.Span[i] = item.CO2;
			_o2.Span[i] = item.O2;
			_temperature.Span[i] = item.Temperature;
			_humidity.Span[i] = item.Humidity;
		}
	}

	public MeasurementMultiList(int capacity)
	{
		_capacity = (uint)capacity;
		_co2 = new Memory<double>(new double[capacity]);
		_o2 = new Memory<double>(new double[capacity]);
		_temperature = new Memory<double>(new double[capacity]);
		_humidity = new Memory<double>(new double[capacity]);
	}
	
	public static void Measure(int count, int intruders)
	{
        var result = new MeasurementMultiList(count);
        var i = 0;
        while (i < count)
        {
	        var item = Measurement.TakeMeasurement(intruders);
            result.Co2[i] = item.CO2; 
            result.O2[i] = item.O2; 
            result.Temperature[i] = item.Temperature; 
            result.Humidity[i] = item.Humidity;
            i++;
        }
	}

	public MeasurementRef GetRef(int index)
	{
		var measurement = new MeasurementRef()
		{
			Co2 = ref _co2.Span[index],
			O2 = ref _o2.Span[index],
			Temperature = ref _temperature.Span[index],
			Humidity = ref _humidity.Span[index]
		};	
		
		return measurement;
	}

	// TODO: Calculate new capacity based on needed capacity as input to this method instead of naively doubling size
	private void Resize()
	{
		// Naively double size for now
		var newCap = _capacity *= 2;
		var newCo2 = new Memory<double>(new double[newCap]);
		var newO2 = new Memory<double>(new double[newCap]);
		var newTemperature = new Memory<double>(new double[newCap]);
		var newHumidity = new Memory<double>(new double[newCap]);
		
		_co2.CopyTo(newCo2);
		_o2.CopyTo(newO2);
		_temperature.CopyTo(newTemperature);
		_humidity.CopyTo(newHumidity);
		
		_co2 = newCo2;
		_o2 = newO2;
		_temperature = newTemperature;
		_humidity = newHumidity;
	}
	
}
