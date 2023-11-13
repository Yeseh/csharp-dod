namespace DataOriented.Tests;

using DataOriented;

public class DataOrientedTests
{
	[Fact]
	public void TestMultiList()
	{
		var measurements = new Measurement[100];
		for (var i = 0; i < measurements.Length; i++)
			measurements[i] = Measurement.TakeMeasurement(100);

		// Should properly initialize
		var first = measurements[0];
		var multiList = new MeasurementMultiList(measurements.AsSpan());
		Assert.Equal(first.CO2, multiList.Co2[0]);
		Assert.Equal(first.O2, multiList.O2[0]);
		Assert.Equal(first.Temperature, multiList.Temperature[0]);
		Assert.Equal(first.Temperature, multiList.Temperature[0]);
		
		// Should update a reference to the underlying memory
		var measurementRef = multiList.GetRef(0);
		measurementRef.O2 = 200;
		Assert.Equal(200, multiList.O2[0]);
	}
}
