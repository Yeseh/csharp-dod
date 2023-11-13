namespace DataOriented;

using System.Runtime.InteropServices;

public static class Memory
{
	private struct AlignmentHelper<T> where T : unmanaged
	{
		public byte Padding;
		public T Target;
	}
	
	public static int AlignmentOf<T>() where T : unmanaged
	{
		return (Int32)  Marshal.OffsetOf<T>(nameof(AlignmentHelper<T>.Target));
	}
}
