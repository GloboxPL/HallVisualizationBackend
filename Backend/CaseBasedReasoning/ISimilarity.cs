using System.Collections.Generic;

namespace Backend.CaseBasedReasoning
{
	public interface ISimilarity<T>
	{
		IEnumerable<T> GetSimilarCases(IEnumerable<T> allCases);
	}
}
