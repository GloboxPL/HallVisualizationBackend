using System.Collections.Generic;

namespace Backend.CBR
{
	public interface ICBRDataSource<T>
	{
		IEnumerable<T> GetData();
	}
}
