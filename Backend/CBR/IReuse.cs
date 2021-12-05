using System.Collections.Generic;

namespace Backend.CBR
{
	public interface IReuse<T>
	{
		IEnumerable<T> SimilarCases { get; init; }

		IEnumerable<T> UsableCases();
	}
}
