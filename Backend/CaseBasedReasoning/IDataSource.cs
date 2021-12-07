using System.Collections.Generic;

namespace Backend.CaseBasedReasoning
{
	public interface IDataSource<T>
	{
		IEnumerable<T> GetFilteredData(params object[] args);
	}
}
