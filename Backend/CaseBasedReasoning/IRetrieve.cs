using System.Collections.Generic;

namespace Backend.CaseBasedReasoning
{
	public interface IRetrieve<T>
	{
		IDataSource<T> DataSource { get; }

		IEnumerable<T> GetSimilarCases()
		{
			return DataSource.GetFilteredData();
		}
	}
}
