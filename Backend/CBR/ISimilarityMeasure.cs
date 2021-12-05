using System.Collections.Generic;

namespace Backend.CBR
{
	public interface ISimilarityMeasure<T>
	{
		IEnumerable<T> GetSimilarCases(IEnumerable<T> allCases);
	}
}
