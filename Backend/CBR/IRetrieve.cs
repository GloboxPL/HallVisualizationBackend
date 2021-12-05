using System.Collections.Generic;

namespace Backend.CBR
{
	public interface IRetrieve<T>
	{
		ISimilarityMeasure<T> SimilarityMeasure { get; init; }
		ICBRDataSource<T> DataSource { get; init; }

		IEnumerable<T> GetSimilarCases();
	}
}
